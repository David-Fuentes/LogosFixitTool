using LogosLoggingUtility.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogosLoggingUtility.Model.Cards
{
    public static class TechToolsCard
    {
        public static void StartEventViewer()
        {
            try
            {
                Process.Start(m_eventViewerPath);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unable to open Event Viewer: \n\n{e}");
            }
        }

        public static void GetProcdump(System.Windows.RoutedEventArgs e)
        {
            e.Handled = true;
            var client = new WebClient();
            client.DownloadFileCompleted += OnFileDownloaded; ;
            client.DownloadFileAsync(new Uri("https://download.sysinternals.com/files/Procdump.zip"), m_procdumpPath);
        }

        private static void OnFileDownloaded(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var installDirectory = FilePathHelper.SetFilePath();
            if (!string.IsNullOrEmpty(installDirectory))
            {
                if (File.Exists($@"{installDirectory}\procdump.exe") || File.Exists($@"{installDirectory}\procdump64.exe"))
                {
                    StartCmd(installDirectory);
                }
                else
                {
                    ZipFile.ExtractToDirectory(m_procdumpPath, installDirectory);
                    StartCmd(installDirectory);
                }
            }

        }

        private static void StartCmd(string installDirectory, bool altCommand = false)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                Arguments = altCommand ? ProcdumpCommand.GetAltCommand(installDirectory) :  ProcdumpCommand.GetCommand(installDirectory),
                FileName = m_cmdPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            process.StartInfo = startInfo;
            process.Start();

            var result = process.StandardOutput.ReadToEnd();
            if (result.Contains("Dump count not reached"))
            {
                if (altCommand)
                {
                    MessageBox.Show("Unable to get procdump via alternate command.");
                }
                else
                {
                    MessageBox.Show("Unable to get procdump. Please retry to recreate crash.");
                    StartCmd(installDirectory, true);
                }
            }
        }


        private static string m_eventViewerPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\eventvwr";
        private static string m_cmdPath= Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd";
        private static string m_procdumpPath = FilePathHelper.s_loggingFolderDefaultFilePath + @"\Procdump.zip";
    }
}
