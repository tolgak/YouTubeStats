using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace YouTubeStats
{
  public static class ControlExtensions
  {
    public delegate void InvokeIfRequiredDelegate<T>(T obj) where T : ISynchronizeInvoke;

    public static void InvokeIfRequired<T>(this T obj, InvokeIfRequiredDelegate<T> action) where T : ISynchronizeInvoke
    {
      if (obj.InvokeRequired)
        obj.Invoke(action, new object[] { obj });
      else
        action(obj);
    }
    public static void Log(this TextBox box, string line)
    {
      line += line.EndsWith(Environment.NewLine) ? string.Empty : Environment.NewLine;
      box.InvokeIfRequired( (x) => {
          x.AppendText($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} {line}");
          box.Refresh();
      } );
    }


    public static StringBuilder AppendConditionally(this StringBuilder sb, bool predicate, string text)
    {
      return predicate ? sb.Append($"{text} {Environment.NewLine}") : sb;
    }

    public static string AggregateExceptionMessages(this Exception ex)
    {
      var result = $"{ex.Source} {ex.Message}";
      if (ex.InnerException != null)
        result = $"{result}\r\n{ex.InnerException.AggregateExceptionMessages()}";

      return result;
    }

  }


}
