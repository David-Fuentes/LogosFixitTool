using LogosLoggingUtility.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace LogosLoggingUtility.View.Tabs
{
    public partial class RemoteView : UserControl
    {
        public RemoteView(LoggingView loggingView)
        {
            m_RemoteViewModel = new RemoteViewModel(loggingView.m_loggingViewModel);
            InitializeComponent();
        }

        private void Connect_CanExecute(object sender, CanExecuteRoutedEventArgs e) {e.CanExecute = true;}
        private void Connect_Executed(object sender, ExecutedRoutedEventArgs e) {m_RemoteViewModel.DownloadTeamviewer();}

        private RemoteViewModel m_RemoteViewModel;
    }
}
