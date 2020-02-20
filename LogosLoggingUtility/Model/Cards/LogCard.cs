using LogosLoggingUtility.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogosLoggingUtility.Model.Cards
{
    public static class LogCard
    {
        public static void ArchiveLogsToDesktop(string folderPath)
        {
            try
            {
                var timeStamp = DateTime.Now.ToString("yyyy''MM''dd'-'HH''mm''ss");
                var desktopPath = FilePathHelper.s_loggingFolderDefaultFilePath;
                Directory.CreateDirectory(desktopPath);

                var zipPath = desktopPath + $@"\Logs-{timeStamp}.zip";

                ZipFile.CreateFromDirectory(folderPath, zipPath);

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = desktopPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
            catch (Exception e)
            {
                MessageBox.Show($"ERROR: Logos must be fully closed before getting logs: {e}");
            }

        }

        public static void EnableLogging()
        {
            var webPath = "https://www.logos.com/media/tech/4xLogging/EnableLogging.js";
            DownloadAndExecuteLoggingFile(webPath);
        }

        public static void DisableLogging()
        {
            var webPath = "https://www.logos.com/media/tech/4xLogging/DisableLogging.js";
            DownloadAndExecuteLoggingFile(webPath);
        }

        private static string GetJsFilePath()
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var jsPath = desktopPath + @"\LogosLogs\EnableLogging.js";
            return jsPath;
        }

        private static void DownloadAndExecuteLoggingFile(string webPath)
        {
            var jsPath = GetJsFilePath();
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(webPath).GetAwaiter().GetResult();
                File.WriteAllText(jsPath, response);
            }

            var process = new Process();
            Process.Start(jsPath);
        }
    }
}
