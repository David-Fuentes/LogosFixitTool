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
    /// Interaction logic for LogCardView.xaml
    /// </summary>
    public partial class LogCardView : UserControl
    {
        public LogCardView()
        {
            InitializeComponent();
            m_SelectedLoggingFolder = FilePathHelper.s_faithlifeDefaultFilePath;
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
                m_SelectedLoggingFolder = e.UpdatedPath;
        }

        private void Bttn_ArchiveLogs_Click(object sender, RoutedEventArgs e)
        {
            LogCard.ArchiveLogsToDesktop(m_SelectedLoggingFolder);
        }

        private string m_SelectedLoggingFolder;
    }
}
