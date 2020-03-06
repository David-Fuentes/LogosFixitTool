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
    /// Interaction logic for RemoteView.xaml
    /// </summary>
    public partial class RemoteView : UserControl
    {
        public RemoteView(LoggingView loggingView)
        {
            m_RemoteViewModel = new RemoteViewModel(loggingView.m_loggingViewModel);
            InitializeComponent();
        }

        private void Connect_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Connect_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            m_RemoteViewModel.DownloadTeamviewer();
        }

        private RemoteViewModel m_RemoteViewModel;
    }
}
