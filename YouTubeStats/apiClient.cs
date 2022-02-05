using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;

using System.Text.RegularExpressions;
using YouTubeStats.Data;


namespace YouTubeStats
{
  public class JsonResult
  {
    public string Result { get; set; }
    public bool Success { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string Description { get; set; }
  }

  public class apiClient
  {
    public string APIKey { get; set; }
    public string BaseUrl { get; set; }

    public async Task<List<PlayListItem>> GetPlayList(string playlistId, string pageToken = "")
    {
      var data = new Dictionary<string, string> {
        ["key"] = this.APIKey,
        ["playlistId"] = playlistId, 
        ["part"] = "snippet", 
        ["fields"] = "nextPageToken,items(snippet(title,resourceId))"
      };

      if (pageToken != string.Empty)
        data.Add("pageToken", pageToken);

      var url = $"{this.BaseUrl}/playlistItems";
      var json = await SendApiRequestAsync(url, data);
      var nextPageToken = string.Empty;
      if (json.Success)
      {
        var playList = new List<PlayListItem>();
        using (JsonDocument document = JsonDocument.Parse(json.Result, new JsonDocumentOptions { AllowTrailingCommas = true}))
        {          
          document.RootElement.TryGetProperty("nextPageToken", out var nextPageTokenElement);
          if (nextPageToken != null)
            nextPageToken = nextPageTokenElement.ToString();
          JsonElement.ArrayEnumerator items = document.RootElement.GetProperty("items").EnumerateArray();
          foreach (var element in items )
          {
            var title = element.GetProperty("snippet").GetProperty("title").ToString();
            if (title == "Private video")
              continue;

            var videoId = element.GetProperty("snippet").GetProperty("resourceId").GetProperty("videoId").ToString();
            playList.Add(new PlayListItem { Title = title, VideoId = videoId });
          }
        }

        if (nextPageToken != string.Empty)
        {
          var nextPage = await GetPlayList(playlistId, nextPageToken);
          playList.AddRange(nextPage);
        }
        return playList;
      }
      else
        return null;
    }

    public async Task<Video> GetVideoStatistics(string videoId, string videoTitle = "")
    {
      var data = new Dictionary<string, string>
      {
        ["key"] = this.APIKey,
        ["id"] = videoId,
        ["part"] = "statistics,snippet",
        ["fields"] = "items(id,snippet(publishedAt,title),statistics(viewCount,likeCount,dislikeCount,commentCount))"
      };

      var url = $"{this.BaseUrl}/videos";
      var json = await SendApiRequestAsync(url, data);     
      if (json.Success)
      {
        var video = new Video();
        using (JsonDocument document = JsonDocument.Parse(json.Result, new JsonDocumentOptions { AllowTrailingCommas = true }))
        {
          JsonElement? items = document?.RootElement.GetProperty("items") ?? null;
          if (items == null)
            return video;

          var descendants = items.Value.EnumerateArray();
          var item  = descendants.FirstOrDefault();

          video.Id = item.GetProperty("id").ToString();
          video.Title = item.GetProperty("snippet").GetProperty("title").ToString();
          var strPublished = item.GetProperty("snippet").GetProperty("publishedAt").ToString();
          video.PublishedAt = Convert.ToDateTime(strPublished);
          video.viewCount = item.GetProperty("statistics").GetProperty("viewCount").ToString();
          video.likeCount = item.GetProperty("statistics").GetProperty("likeCount").ToString();
          //video.dislikeCount = item.GetProperty("statistics").GetProperty("dislikeCount").ToString();
          video.commentCount = item.GetProperty("statistics").GetProperty("commentCount").ToString();
        }
        return video;
      }
      else
        return new Video();
    }

    public async Task<ChannelStat> GetChannelStatistics(string channelId)
    {
      
      var data = new Dictionary<string, string>
      {
        ["key"] = this.APIKey,
        ["id"] = channelId,
        ["part"] = "statistics",
        ["fields"] = "items(id,statistics(viewCount,subscriberCount,videoCount))"
      };

      var url = $"{this.BaseUrl}/channels";
      var json = await SendApiRequestAsync(url, data);

      if (json.Success)
      {
        var regexPattern = "\"viewCount\":.*\"(?<viewCount>\\d*)\",\\s*\"subscriberCount\":.*\"(?<subscriberCount>\\d*)\"";
        var match = Regex.Match(json.Result, regexPattern);       
        return new ChannelStat{ ChannelId = channelId, ViewCount = match.Groups["viewCount"].Value, SubscriberCount=  match.Groups["subscriberCount"].Value};
      }
      else
        return new ChannelStat();
     
    }

    private async Task<JsonResult> SendApiRequestAsync(string resourceUrl, Dictionary<string, string> data, string method ="GET")
    {
      var queryParams = string.Empty;
      if (data != null)
        queryParams = data.Aggregate(queryParams, (accumulator, kvp) => accumulator += $"{kvp.Key}={kvp.Value}&");

      var url = $"{resourceUrl}?{queryParams}";
      var request = HttpWebRequest.CreateHttp(url);
      request.ContentType = "application/json";
      request.Method = method;

      HttpWebResponse response = null;
      try
      {
        response = await request.GetResponseAsync() as HttpWebResponse;
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
          return new JsonResult { Success = true, Result = reader.ReadToEnd(), StatusCode = response.StatusCode, Description = response.StatusDescription };
        }
      }
      catch (WebException ex)
      {
        var jsonRespone = new JsonResult { Success = false, Result = string.Empty };
        if (ex.Response != null)
        {
          using (var errorResponse = (HttpWebResponse) ex.Response)
          {
            var reader = new StreamReader(errorResponse.GetResponseStream());
            jsonRespone.StatusCode = errorResponse.StatusCode;
            jsonRespone.Description = reader.ReadToEnd();
          }
        }
        else
        {
          jsonRespone.StatusCode = HttpStatusCode.InternalServerError;
          jsonRespone.Description = "No response received";
        }

        if (request != null)
          request.Abort();

        return jsonRespone;
      }
      finally
      {
        if (response != null)
          response.Close();
      }
    }




  }
}
