using System;
using Dapper;

using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace YouTubeStats.Data
{

  public class pocoStats_Long
  {
    public DateTime? RequestBegin { get; set; }
    public DateTime? RequestEnd { get; set; }
    public string RequestBeginAsString => this.RequestEnd?.ToString("dd.MM.yyyy HH:mm:ss");
    public string RequestEndAsString => this.RequestEnd?.ToString("dd.MM.yyyy HH:mm:ss");
    public bool RequestSuccess { get; set; }
    public string RequestErrorMessage { get; set; }

    public string ChannelId { get; set; }
    public string ChannelViewCount { get; set; }
    public string SubscriberCount { get; set; }

    public string Title { get; set; }
    public string VideoId { get; set; }
    public string viewCount { get; set; }
    public int viewDelta { get; set; }
    public string likeCount { get; set; }
    public string dislikeCount { get; set; }
    public string commentCount { get; set; }
  }

  public class History
  {
    public DateTime? RequestBegin { get; set; }      
    public string SubscriberCount { get; set; }

    [QueryParamIgnore]
    public string Title { get; set; }
    public string VideoId { get; set; }
    public string viewCount { get; set; }
    [Browsable(false)]
    [QueryParamIgnore]
    public int viewDelta { get; set; }
    public string likeCount { get; set; }
    public string dislikeCount { get; set; }
    public string commentCount { get; set; }

    [Browsable(false)]
    [QueryParamIgnore]
    public string ChannelId { get; set; }
    [Browsable(false)]
    [QueryParamIgnore]
    public string ChannelViewCount { get; set; }
    [Browsable(false)]
    public DateTime? RequestEnd { get; set; }

    public bool RequestSuccess { get; set; }
    public string RequestErrorMessage { get; set; }

  }
}
