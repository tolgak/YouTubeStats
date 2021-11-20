using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YouTubeStats.Data
{
  [Table("Channel")]
  public class ChannelStat
  {
    [Key]
    public string ChannelId { get; set; }
    public string ViewCount { get; set; }
    public string SubscriberCount { get; set; }
  }
}
