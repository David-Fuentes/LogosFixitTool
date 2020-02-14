using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogosLoggingUtility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var faithlifeFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Faithlife\Logs";
            var logosFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Logos";
            var verbumFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Verbum";

            if (Directory.Exists(faithlifeFilePath))
                m_FaithlifeFilePath = faithlifeFilePath;
            else
                bttn_Logs.IsEnabled = false;

            if (Directory.Exists(logosFilePath + @"\Data"))
            {
                m_LogosFilePath = logosFilePath;
                m_isLogos4Directory = false;
            }
            else if (Directory.Exists(logosFilePath + @"4\Data"))
            {
                m_LogosFilePath = logosFilePath + "4";
                m_isLogos4Directory = true;
            }
            else
            {
                bttn_Repair_Logos.IsEnabled = false;
            }

            if (Directory.Exists(verbumFilePath + @"\Data"))
                m_LogosFilePath = verbumFilePath;
            else
                bttn_Repair_Verbum.IsEnabled = false;

        }


        private void Bttn_Logs_Click(object sender, RoutedEventArgs e)
        {
            ArchiveLogsToDesktop(m_FaithlifeFilePath);
        }

        private void Bttn_Repair_Logos_Click(object sender, RoutedEventArgs e)
        {
            RepairInstallation();
        }

        

        private void Bttn_Repair_Verbum_Click(object sender, RoutedEventArgs e)
        {
            RepairInstallation();
        }

        private void RepairInstallation()
        {
            try
            {
                var msiPath = m_LogosFilePath + @"\Install\Installers\" + (m_isLogos4Directory ? @"Logos4Prerequisites.msi" : @"Logos-x64.msi");
                Process.Start(msiPath);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unable to open repair file: {e}");
            }
            

        }

        private void ArchiveLogsToDesktop(string folderPath)
        {
            try
            {
                var timeStamp = DateTime.Now.ToString("yyyy''MM''dd'-'HH''mm''ss");
                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LogosLogs";
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
                MessageBox.Show($"ERROR: Logos must be fully closed before getting logs!");
            }
            
        }


        private string m_FaithlifeFilePath;
        private string m_LogosFilePath;
        private bool m_isLogos4Directory;

        private void Bttn_Enable_Logging_Click(object sender, RoutedEventArgs e)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var jsPath = desktopPath + @"\LogosLogs\EnableLogging.js";
            var webPath = "https://www.logos.com/media/tech/4xLogging/EnableLogging.js";

            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(webPath).GetAwaiter().GetResult();
                File.WriteAllText(jsPath, response);
            }

            var process = new Process();
            Process.Start(jsPath);
        }

        private void Bttn_Disalbe_Logging_Click(object sender, RoutedEventArgs e)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var jsPath = desktopPath + @"\LogosLogs\DisableLogging.js";
            var webPath = "https://www.logos.com/media/tech/4xLogging/DisableLogging.js";

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
