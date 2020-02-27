using LogosLoggingUtility.Model.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
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
            var commandArg = altCommand ? CommandHelper.GetAltProcdumpCommand(installDirectory) : CommandHelper.GetProcdumpCommand(installDirectory);

            var result = OpenCommandPromptWithCommand(commandArg);

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

        public static void RunBits()
        {
            var result = OpenCommandPromptWithCommand(CommandHelper.BitsCommand);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("BITS has failed to respond. Please contact a Faithlife Technical Support rep.");
                return;
            }
            var pattern = @"Listed \d job";

            var match = Regex.Match(result, pattern, RegexOptions.None);
            if (match.Success)
            {
                var jobs = match.Value.Split(' ')[1];
                if (int.TryParse(jobs, out var jobNumber) && jobNumber > 0)
                {
                    OpenCommandPromptWithCommand(CommandHelper.BitsReset);
                    MessageBox.Show("BITS jobs have been reset.");
                }
                else if (jobNumber == 0)
                {
                    MessageBox.Show("You have no BITS jobs.");
                }
                else
                {
                    MessageBox.Show("Unable to detect number of BITS jobs. Please contact Faithlife Technical Support.");
                }
            }
            else
            {
                MessageBox.Show($"ERROR: There was a problem with running BITS. \n\n{result}");
            }
        }

        private static string OpenCommandPromptWithCommand(string commandArg)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo()
            {
                Arguments = commandArg,
                FileName = m_cmdPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            process.StartInfo = startInfo;
            process.Start();
            return process.StandardOutput.ReadToEnd();
        }

        private static string m_eventViewerPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\eventvwr";
        private static string m_cmdPath= Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd";
        private static string m_procdumpPath = FilePathHelper.s_loggingFolderDefaultFilePath + @"\Procdump.zip";
    }
}
