using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTubeStats
{
  static class Program
  {

    private static IConfigurationRoot _configuration;
    public static IConfigurationRoot Configuration => _configuration;

    private static frmMain _mainForm;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      Application.ThreadException += Application_ThreadException;
      Startup();
    }

    private static void Startup()
    {
      var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
      _configuration = builder.Build();

      _mainForm = new frmMain();
      Application.Run(_mainForm);
    }

    public static string GetConnectionString(string key) => _configuration.GetSection("ConnectionStrings")
                                                                          .GetChildren()
                                                                          .FirstOrDefault(x => x.Key == key).Value ?? string.Empty;
    public static string GetAPIKey(string key) => _configuration.GetSection("YouTubeDataAPI")
                                                                          .GetChildren()
                                                                          .FirstOrDefault(x => x.Key == key).Value ?? string.Empty;

    public static void Log(string message)
    {
      _mainForm.Log(message);
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }


  }
}
