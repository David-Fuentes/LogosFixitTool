using LogosLoggingUtility.Model.Helpers;
using LogosLoggingUtility.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace LogosLoggingUtility.View.Tabs
{
    /// <summary>
    /// Interaction logic for TechToolsView.xaml
    /// </summary>
    public partial class TechToolsView : UserControl
    {
        public TechToolsView(SupportViewModel supportViewModel, LoggingViewModel loggingViewModel)
        {
            m_techToolsViewModel = new TechToolsViewModel(supportViewModel, loggingViewModel);
            InitializeComponent();
        }

        private void StartEventViewer_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void StartEventViewer_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            m_techToolsViewModel.StartEventViewer();
        }

        private void GetProcdump_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = m_techToolsViewModel.CanGetProcdump();
        }

        private void GetProcdump_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            m_techToolsViewModel.GetProcdump();
        }

        private void ResetBits_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ResetBits_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            m_techToolsViewModel.RunBits();
        }

        private TechToolsViewModel m_techToolsViewModel;

        
    }
}
