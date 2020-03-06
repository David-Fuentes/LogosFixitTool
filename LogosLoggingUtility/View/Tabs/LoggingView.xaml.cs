using LogosLoggingUtility.ViewModels;
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

namespace LogosLoggingUtility.View.Tabs
{
    /// <summary>
    /// Interaction logic for LoggingView.xaml
    /// </summary>
    public partial class LoggingView : UserControl
    {
        public LoggingView()
        {
            m_loggingViewModel = new LoggingViewModel();
            DataContext = m_loggingViewModel;
            InitializeComponent();
        }

        private LoggingViewModel m_loggingViewModel;

        private void EnableLogging_CanExecute(object sender, CanExecuteRoutedEventArgs e) {e.CanExecute = true;}
        private void EnableLogging_Executed(object sender, ExecutedRoutedEventArgs e) {m_loggingViewModel.EnableLogging();}

        private void DisableLogging_CanExecute(object sender, CanExecuteRoutedEventArgs e) {e.CanExecute = true;}
        private void DisableLogging_Executed(object sender, ExecutedRoutedEventArgs e) {m_loggingViewModel.DisableLogging();}

        private void ArchiveLogs_CanExecute(object sender, CanExecuteRoutedEventArgs e) {e.CanExecute = m_loggingViewModel.CanArchiveLogs();}
        private void ArchiveLogs_Executed(object sender, ExecutedRoutedEventArgs e) {m_loggingViewModel.ArchiveLogs();}

        private void ChangeExportPath_CanExecute(object sender, CanExecuteRoutedEventArgs e) {e.CanExecute = true;}
        private void ChangeExportPath_Executed(object sender, ExecutedRoutedEventArgs e) {m_loggingViewModel.UpdateExportParth();}
    }
}
