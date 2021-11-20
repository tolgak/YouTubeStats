using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Shorthand;
using YouTubeStats.Data;
using YouTubeStats.Data.Conracts;

namespace YouTubeStats
{
  public partial class frmMain : Form
  {
    private int _autoCheckInterval = 30 * 60000;
    private int _nextRequest;
    private bool _ignoreFurtherRequest;
    private string _connectionString;

    private IRepository<History> _repo;
    private apiClient _apiClient;

    public frmMain()
    {
      InitializeComponent();

      timerRequest.Enabled = false;
      timerRequest.Interval = 1000;
      _ignoreFurtherRequest = false;
      _nextRequest = _autoCheckInterval;

      var youTubeAPIKey = Program.Configuration.GetSection("YouTubeDataAPI")["APIKey"];
      var baseUrl = Program.Configuration.GetSection("YouTubeDataAPI")["BaseUrl"];
      _apiClient = new apiClient { APIKey = youTubeAPIKey, BaseUrl = baseUrl };

      _connectionString = Program.GetConnectionString("YouTubeStats");
      _repo = new SQLiteRepository<History>(_connectionString);
      tabs.SelectedTab = tabLatestReading;

      this.Log($"started in {AppDomain.CurrentDomain.BaseDirectory}");
    }

    private void chkTimerEnabled_Click(object sender, EventArgs e)
    {
      timerRequest.Enabled = chkTimerEnabled.Checked;
      btnRequest.Text = "request";

      _ = int.TryParse(txtWait.Text, out int minToWait);
      _autoCheckInterval = minToWait * 60 * 1000;
      _nextRequest = _autoCheckInterval;
    }

    private async void btnRequest_Click(object sender, EventArgs e)
    {
      if (_ignoreFurtherRequest)
        return;

      _ignoreFurtherRequest = true;

      var playlistId = txtPlayList.Text;
      var channelId = txtChannelId.Text;

      try
      {
        Cursor = Cursors.WaitCursor;
        btnRequest.Text = "requesting ...";
        var stats = await GetStatistics(channelId, playlistId);
        if (stats?.VideoStats != null)
        {
          var v_repo = new SQLiteRepository<Video>(_connectionString);
          stats.VideoStats.ForEach(async x => await v_repo.SaveOrUpdate(x));

          await _repo.AddRangeAsync(stats.ToPoco());
        }

        RenderStats(stats);
        tabs.SelectedTab = tabLatestReading;
      }
      finally
      {
        btnRequest.Text = "request";
        _ignoreFurtherRequest = false;
        Cursor = Cursors.Default;
      }
    }

    private void timerRequest_Tick(object sender, EventArgs e)
    {
      _nextRequest -= timerRequest.Interval;
      if (_nextRequest <= 0)
      {
        btnRequest_Click(timerRequest, new EventArgs());
        _nextRequest = _autoCheckInterval;
      }

      btnRequest.Text = $"request (auto in {_nextRequest / 1000} seconds)";
    }

    private void RenderStats(vmStats stats)
    {
      try
      {
        this.Log("Request begin");
        txtSubscribers.Text = stats.ChannelStat.SubscriberCount;
        lblNow.Text = $"{stats.RequestEnd?.ToString("dd.MM.yyyy HH:mm:ss")}";
        var span = stats.RequestEnd.Value.Subtract(stats.RequestBegin.Value);
        this.Log($"Request end. {stats.RequestErrorMessage} in {span.Milliseconds} ms.");

        txtTotalViewCount.Text = stats.VideoStats.Sum(x => x.viewCount.ToInt()).ToString();

        var previousData = bsVideo.DataSource as List<Video>;
        if (previousData != null)
          stats.VideoStats.ForEach(x =>
          {
            var previousViewCount = previousData.FirstOrDefault(y => y.Id == x.Id)?.viewCount ?? "0";
            x.viewDelta = x.viewCount.ToInt() - previousViewCount.ToInt();
          });

        bsVideo.DataSource = stats.VideoStats;
        grdStat.DataSource = bsVideo;
        tabs.SelectedTab = tabLatestReading;
      }
      catch (Exception ex)
      {
        this.Log(ex.Message);
      }

    }

    private async Task<vmStats> GetStatistics(string channelId, string playlistId)
    {
      var result = new vmStats { RequestBegin = DateTime.Now };
      var channelStat = await _apiClient.GetChannelStatistics(channelId);
      result.ChannelStat = channelStat;

      var playList = await _apiClient.GetPlayList(playlistId);
      if (playList?.Count > 0)
      {
        var tasks = new List<Task<Video>>();
        playList.ForEach(item => tasks.Add(_apiClient.GetVideoStatistics(item.VideoId, item.Title)));
        var v = await Task.WhenAll(tasks);

        result.VideoStats = new List<Video>(v);
        result.RequestSuccess = true;
        result.RequestErrorMessage = "OK";
      }
      else
      {
        result.RequestErrorMessage = "Playlist returned no videos";
      }
      result.RequestEnd = DateTime.Now;
      return result;
    }


    private void grdStat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      var row = grdStat.Rows[e.RowIndex];
      var viewDelta = (row.DataBoundItem as Video).viewDelta;

      row.Cells["viewDelta"].Style.BackColor = viewDelta switch
      {
        _ when viewDelta > 0 => Color.LawnGreen,
        _ when viewDelta < 0 => Color.IndianRed,
        _ => row.DefaultCellStyle.BackColor
      };
    }


    public void Log(string message)
    {
      txtLog.Log(message);
    }

    private void btnOpenAppFolder_Click(object sender, EventArgs e)
    {
      var appFolder = AppDomain.CurrentDomain.BaseDirectory;
      Process.Start(new ProcessStartInfo(appFolder) { UseShellExecute = true });
    }

    private async void mnuHistory_Click(object sender, EventArgs e)
    {
      var row = grdStat.CurrentRow;
      if (row == null)
        return;

      var id = (row.DataBoundItem as Video)?.Id;
      var history = await GetHistory(id);

      bsHistory.DataSource = history;
      grdHistory.DataSource = bsHistory;
      tabs.SelectedTab = tabHistory;
    }

    private async Task<List<History>> GetHistory(string id)
    {
      var result = new List<History>();
      try
      {
        var sql = await File.ReadAllTextAsync("./Query/queryHistory.sql");
        var runner = new SQLiteQueryProcessor(_connectionString);
        result = await runner.RunQuery(sql, new { Id = id });
      }
      catch (Exception ex)
      {
        this.Log(ex.Message);
      }

      return result;
    }

    private void mnuOpen_Click(object sender, EventArgs e)
    {
      var row = grdStat.CurrentRow;
      if (row == null)
        return;

      var id = (row.DataBoundItem as Video)?.Id;
      var url = $"https://youtu.be/{id}";
      Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
    }

    private void grdStat_DoubleClick(object sender, EventArgs e)
    {
      mnuHistory_Click(sender, e);
    }
  }
}
