
using Shorthand;
using System;
using System.ComponentModel;

using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouTubeStats.Data
{
  [Table("Video")]
  public class Video
  {
    [Browsable(false)]
    [Key]
    public string Id { get; set; }
    public string Title { get; set; }
    public string viewCount { get; set; }
    [QueryParamIgnore]
    public int viewDelta { get; set; }
    public string likeCount { get; set; }
    public string dislikeCount { get; set; }
    public string commentCount { get; set; }
    public DateTime PublishedAt { get; set; }
    [QueryParamIgnore]
    public int DaysOnAir => DateTime.Now.Subtract(this.PublishedAt).Days;
    [QueryParamIgnore]
    public decimal AverageDailyView => this.DaysOnAir == 0 ? viewCount.ToInt() : viewCount.ToInt() / DaysOnAir;
  }



}
