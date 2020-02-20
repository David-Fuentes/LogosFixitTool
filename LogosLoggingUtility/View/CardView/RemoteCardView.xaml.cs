using LogosLoggingUtility.Model.Cards;
using LogosLoggingUtility.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
