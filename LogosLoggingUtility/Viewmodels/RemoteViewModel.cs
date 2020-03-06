using LogosLoggingUtility.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogosLoggingUtility.ViewModels
{
    public class RemoteViewModel
    {
        public RemoteViewModel(LoggingViewModel viewModel)
        {
            m_remoteModel = new RemoteModel(viewModel);
        }


        internal void DownloadTeamviewer()
        {
            if (File.Exists(m_remoteModel.DownloadLocation))
                LaunchTeamviewer();

            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                client.DownloadFileAsync(new Uri(m_remoteModel.TeamviewerDownloadUrl), m_remoteModel.DownloadLocation);
            }
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Download Complete");
            LaunchTeamviewer();
        }

        private void LaunchTeamviewer()
        {
            Process.Start(m_remoteModel.DownloadLocation);
        }

        private readonly RemoteModel m_remoteModel;

    }
}
