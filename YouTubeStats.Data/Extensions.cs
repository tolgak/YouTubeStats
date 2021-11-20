using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Shorthand
{

  public static class Extensions
  {
    public static int ToInt(this string str, int defaultValue = 0)
    {      
      return int.TryParse(str, out int result) ? result : defaultValue;
    }

    public static string ToTidyString(this string str)
    {
      if (string.IsNullOrWhiteSpace(str))
        return string.Empty;

      var x = str.Replace("\n", string.Empty);
      return Regex.Replace(x, "\\s+", " ").Trim();
    }

  }


}
