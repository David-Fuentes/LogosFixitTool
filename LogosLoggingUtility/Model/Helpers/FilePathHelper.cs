using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace LogosLoggingUtility.Model.Helpers
{
    public static class FilePathHelper
    {
        public static (bool logosWasFound, bool logos4WasFound, bool faithlifeWasFound, bool verbumWasFound) LocateLogosFolders()
        {
            var logosWasFound = Directory.Exists (s_logosDefaultFilePath + @"\Data");
            var logos4WasFound = Directory.Exists (s_logosDefaultFilePath + @"4\Data");
            var faithlifeWasFound = Directory.Exists(s_faithlifeDefaultFilePath);
            var verbumWasFound = Directory.Exists(s_verbumDefaultFilePath + @"\Data");
            return (logosWasFound, logos4WasFound, faithlifeWasFound, verbumWasFound);
        }

        public static string SetNewFilePath()
        {
            var filePath = "";
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.FileName = "Select App";
                fileDialog.Filter = "Application (*.exe)|*.exe";
                fileDialog.Title = "Find Application";

                var result = fileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fileDialog.FileName))
                    filePath = Directory.GetParent(fileDialog.FileName).FullName;
            }

            return filePath;
        }

        public static string SetNewFolderPath()
        {
            var folderPath = "";
            using (var folderDialog = new FolderBrowserDialog())
            {
                var result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                    folderPath = folderDialog.SelectedPath;
            }

            return folderPath;
        }

        public static void OpenFileExplorerToPath(string path)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = path,
                FileName = "explorer.exe"
            };
            Process.Start(startInfo);
        }

        public static string s_faithlifeDefaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Faithlife\Logs";
        public static string s_logosDefaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Logos";
        public static string s_verbumDefaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Verbum";
        public static string s_loggingFolderDefaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LogosLogs";
    }
}
