using LogosLoggingUtility.Model;
using LogosLoggingUtility.Model.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;

namespace LogosLoggingUtility.ViewModels
{
    public class TechToolsViewModel : ViewModel
    {
        public TechToolsViewModel(SupportViewModel supportViewModel, LoggingViewModel loggingViewModel )
        {
            m_supportViewModel = supportViewModel;
            m_loggingViewModel = loggingViewModel;
            m_techToolsModel = new TechToolsModel(loggingViewModel);
            ProcdumpCommand = CommandHelper.GetProcdumpCommand(m_supportViewModel.FilePath, m_supportViewModel.PreferredSoftware);
            ProcdumpCommandAlt = CommandHelper.GetAltProcdumpCommand(m_supportViewModel.FilePath, m_supportViewModel.PreferredSoftware);
        }
        internal void StartEventViewer()
        {
            try
            {
                Process.Start(m_techToolsModel.EventViewerPath);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unable to open Event Viewer: \n\n{e}");
            }
        }

        internal bool CanGetProcdump()
        {
            return !ProcessHelper.LogosOrVerbumIsOpen() && m_supportViewModel.SoftwareFound;
        }

        internal void GetProcdump()
        {
            var client = new WebClient();
            client.DownloadFileCompleted += OnFileDownloaded;
            Directory.CreateDirectory(m_loggingViewModel.ExportPath);
            client.DownloadFileAsync(new Uri("https://download.sysinternals.com/files/Procdump.zip"), m_techToolsModel.ProcdumpPath);
        }

        internal void RunBits()
        {
            var result = OpenCommandPromptWithCommand(m_techToolsModel.BitsCommand);
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
                    OpenCommandPromptWithCommand(m_techToolsModel.BitsReset);
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

        private void OnFileDownloaded(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (File.Exists($@"{m_supportViewModel.FilePath}\procdump.exe") || File.Exists($@"{m_supportViewModel.FilePath}\procdump64.exe"))
            {
                StartProcdumpCmd(false);
            }
            else
            {
                try
                {
                    ZipFile.ExtractToDirectory(m_techToolsModel.ProcdumpPath, m_supportViewModel.FilePath);
                    StartProcdumpCmd(false);
                }
                catch (IOException exception)
                {
                    GetProcdump();
                }
                
            }
        }

        private void StartProcdumpCmd(bool altCommand = false)
        {
            var commandArg = altCommand ? 
                CommandHelper.GetAltProcdumpCommand(m_supportViewModel.FilePath, m_supportViewModel.PreferredSoftware): 
                CommandHelper.GetProcdumpCommand(m_supportViewModel.FilePath, m_supportViewModel.PreferredSoftware);

            Process.Start($@"{m_supportViewModel.FilePath}\Procdump.exe");

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
                    StartProcdumpCmd(true);
                }
            }
            else
            {
                FilePathHelper.OpenFileExplorerToPath(m_supportViewModel.FilePath);
            }
        }

        private string OpenCommandPromptWithCommand(string commandArg)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo()
            {
                Arguments = commandArg,
                FileName = m_techToolsModel.CmdPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            process.StartInfo = startInfo;
            process.Start();
            return process.StandardOutput.ReadToEnd();
        }

        private string m_procdumpCommand;
        public string ProcdumpCommand
        {
            get { return m_procdumpCommand; }
            set { m_procdumpCommand = value; OnPropertyChanged("ProdcumpCommand"); }
        }

        private string m_procdumpCommandAlt;
        public string ProcdumpCommandAlt
        {
            get { return m_procdumpCommandAlt ; }
            set { m_procdumpCommandAlt = value; OnPropertyChanged("ProdcumpCommandAlt"); }
        }

        private readonly SupportViewModel m_supportViewModel;
        private readonly TechToolsModel m_techToolsModel;
        private readonly LoggingViewModel m_loggingViewModel;
    }
}
