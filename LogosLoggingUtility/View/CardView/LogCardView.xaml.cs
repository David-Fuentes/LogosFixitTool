using LogosLoggingUtility.Model.Cards;
using LogosLoggingUtility.Model.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace LogosLoggingUtility.View.CardView
{
    /// <summary>
    /// Interaction logic for LogCardView.xaml
    /// </summary>
    public partial class LogCardView : UserControl
    {
        public LogCardView()
        {
            InitializeComponent();
            LoggingEventHelper.OnFilePathChanged += OnFilePathUpdated;
        }

        private void Bttn_EnableLogging_Click(object sender, RoutedEventArgs e)
        {
            LogCard.EnableLogging();
        }

        private void Bttn_DisableLogging_Click(object sender, RoutedEventArgs e)
        {
            LogCard.DisableLogging();
        }

        private void OnFilePathUpdated(object sender, PathUpdateEventArgs e)
        {
            if (e.FileType == RepairCard.FileType.Log)
                FilePathHelper.s_faithlifeDefaultFilePath = e.UpdatedPath;
        }

        private void Bttn_ArchiveLogs_Click(object sender, RoutedEventArgs e)
        {
            LogCard.ArchiveLogsToDesktop(FilePathHelper.s_faithlifeDefaultFilePath);
        }
    }
}
