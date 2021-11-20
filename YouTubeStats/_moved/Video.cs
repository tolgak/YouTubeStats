
using Shorthand;
using System;
using System.ComponentModel;

using System.Collections.Generic;
using System.Text;

namespace YouTubeStats
{
  public class Video
  {
    public string Title { get; set; }

    [Browsable(false)]
    public string Id { get; set; }

    public string viewCount { get; set; }
    public int viewDelta { get; set; }
    public string likeCount { get; set; }
    public string dislikeCount { get; set; }
    public string commentCount { get; set; }

    public DateTime PublishedAt { get; set; }
    public int DaysOnAir => DateTime.Now.Subtract(this.PublishedAt).Days;
    public decimal AverageDailyView => this.DaysOnAir == 0 ? viewCount.ToInt() : viewCount.ToInt() / DaysOnAir;
  }



}
