using System;
using System.Collections.Generic;
using System.Text;

namespace YouTubeStats
{
  public class PlayList
  {
    public List<PlayListItem> Items { get; set; }
  }

  public class PlayListItem
  {
    public string Title { get; set; }
    public string VideoId { get; set; }
  }

}
