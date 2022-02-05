using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTubeStats.Data;

namespace YouTubeStats
{
  public class vmStats
  {
    public DateTime? RequestBegin { get; set; }
    public DateTime? RequestEnd { get; set; }
    public bool RequestSuccess { get; set; }
    public string RequestErrorMessage { get; set; }
    public ChannelStat ChannelStat { get; set; }
    public List<Video> VideoStats { get; set; }

    public List<History> ToPoco() => VideoStats?.Select(x => new History { RequestBegin = this.RequestBegin
                                           , RequestEnd = this.RequestEnd
                                           , RequestSuccess = this.RequestSuccess
                                           , RequestErrorMessage = this.RequestErrorMessage
                                           , ChannelId = this.ChannelStat.ChannelId
                                           //, ChannelViewCount = this.ChannelStat.ViewCount
                                           , SubscriberCount = this.ChannelStat.SubscriberCount
                                           , VideoId = x.Id, Title = x.Title
                                           , viewCount = x.viewCount, viewDelta = x.viewDelta, likeCount = x.likeCount
                                           //, dislikeCount = x.dislikeCount
                                           , commentCount = x.commentCount }).ToList();    
  }





}
