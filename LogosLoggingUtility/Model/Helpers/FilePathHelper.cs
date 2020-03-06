using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LogosLoggingUtility.Model.Helpers
{
    public static class FilePathHelper
    {
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
        public static string s_loggingFolderDefaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LogosLogs";
    }
}
