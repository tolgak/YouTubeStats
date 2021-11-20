using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YouTubeStats.Data
{
  [Table("PlayList")]
  public class PlayList
  {
    public List<PlayListItem> Items { get; set; }
  }

  [Table("PlayListItem")]
  public class PlayListItem
  {
    public string Title { get; set; }
    public string VideoId { get; set; }
  }

}
