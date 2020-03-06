using LogosLoggingUtility.Model;
using LogosLoggingUtility.Model.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace LogosLoggingUtility.ViewModels
{
    public class LoggingViewModel : ViewModel
    {
        public LoggingViewModel()
        {
            m_loggingModel = new LoggingModel();
            ExportPath = FilePathHelper.loggingFolderDefaultFilePath;
            LoggingStatus = m_loggingModel.IsLoggingEnabled;
        }

        internal void ArchiveLogs()
        {
            var timeStamp = DateTime.Now.ToString("MMM'_'dd'_'yyyy'-'hh'_'mm'_'ss'_'tt");
            Directory.CreateDirectory(ExportPath);

            var zipPath = ExportPath+ $@"\Logs-{timeStamp}.zip";
            ZipFile.CreateFromDirectory(FilePathHelper.faithlifeDefaultFilePath, zipPath);

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = ExportPath,
                FileName = "explorer.exe"
            };
            Process.Start(startInfo);
        }

        internal void EnableLogging()
        {
            RegistryHelper.SetLoggingValue(true);
            LoggingStatus = "Enabled";
        }

        internal void DisableLogging()
        {
            RegistryHelper.SetLoggingValue(false);
            LoggingStatus = "Disabled";
        }

        internal bool CanArchiveLogs()
        {
            return !ProcessHelper.LogosOrVerbumIsOpen();
        }

        internal void UpdateExportParth()
        {
            var result = FilePathHelper.SetNewFolderPath();
            if (!string.IsNullOrEmpty(result))
                ExportPath = result;
        }

        private LoggingModel m_loggingModel;

        private string m_loggingStatus;
        public string LoggingStatus
        {
            get { return m_loggingStatus; }
            set { m_loggingStatus = value; OnPropertyChanged("LoggingStatus"); }
        }

        private string m_exportPath;
        public string ExportPath
        {
            get { return m_exportPath; }
            set { m_exportPath = value; OnPropertyChanged("ExportPath"); }
        }
    }
}
