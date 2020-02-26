using LogosLoggingUtility.Model.Cards;
using LogosLoggingUtility.Model.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LogosLoggingUtility.View.CardView
{
    /// <summary>
    /// Interaction logic for RemoteCardView.xaml
    /// </summary>
    public partial class RemoteCardView : UserControl
    {
        public RemoteCardView()
        {
            InitializeComponent();
            LoggingEventHelper.OnDownloadFinished += LoggingEventHelper_OnDownloadFinished;
        }

        private void LoggingEventHelper_OnDownloadFinished(object sender, EventArgs e)
        {
            Bttn_DownloadTeamviewer.IsEnabled = true;
        }

        private void Bttn_DownloadTeamviewer_Click(object sender, RoutedEventArgs e)
        {
            RemoteCard.DownloadTeamviewer();
            Bttn_DownloadTeamviewer.IsEnabled = false;
        }
    }
}
