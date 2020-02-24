using LogosLoggingUtility.Model.Helpers;
using Microsoft.Win32;
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
            SetLoggingValue(true);
            MessageBox.Show("Logging is now enabled");
        }

        public static void DisableLogging()
        {
            SetLoggingValue(false);
            MessageBox.Show("Logging is now disabled");
        }

        private static void SetLoggingValue(bool value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Logos4\Logging"))
            {
                key.SetValue("Enabled", value ? 1 : 0);
            }
        }
    }
}
