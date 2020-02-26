using LogosLoggingUtility.Model.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace LogosLoggingUtility.Model.Cards
{
    public static class RemoteCard
    {
        public static void DownloadTeamviewer()
        {
            if (File.Exists(m_defaultDownloadLocation))
                LaunchTeamviewer();

            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                client.DownloadFileAsync(new Uri(m_teamviewerDownloadUrl), m_defaultDownloadLocation);
            }
        }

        private static void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Download Complete");
            LaunchTeamviewer();
            LoggingEventHelper.RaiseDownloadFinishedEvent(sender, e);
        }

        private static void LaunchTeamviewer()
        {
            Process.Start(m_defaultDownloadLocation);

        }

        private static string m_teamviewerDownloadUrl = "https://www.logos.com/media/tech/TeamViewer_QS/TeamViewerQS.exe";
        private static string m_defaultDownloadLocation = FilePathHelper.s_loggingFolderDefaultFilePath + @"\TeamviewerQS.exe";
    }
}
