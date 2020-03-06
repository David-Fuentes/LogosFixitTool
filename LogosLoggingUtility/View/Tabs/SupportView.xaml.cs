using LogosLoggingUtility.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace LogosLoggingUtility.View.Tabs
{
    public partial class SupportView : UserControl
    {
        public SupportView()
        {
            m_supportViewModel = new SupportViewModel();
            DataContext = m_supportViewModel;
            InitializeComponent();
        }

        private void SwitchSoftware_CanExecute(object sender, CanExecuteRoutedEventArgs e) {e.CanExecute = m_supportViewModel.CanSwitchSoftware();}
        private void SwitchSoftware_Executed(object sender, ExecutedRoutedEventArgs e) {m_supportViewModel.ChangePreferredSoftware();}

        private void OpenSoftware_CanExecute(object sender, CanExecuteRoutedEventArgs e) {e.CanExecute = m_supportViewModel.CanOpenSoftware();}
        private void OpenSoftware_Executed(object sender, ExecutedRoutedEventArgs e) {m_supportViewModel.OpenSoftware();}

        private void OpenFolderLocation_CanExecute(object sender, CanExecuteRoutedEventArgs e) {e.CanExecute = m_supportViewModel.CanOpenSoftware();}
        private void OpenFolderLocation_Executed(object sender, ExecutedRoutedEventArgs e) {m_supportViewModel.OpenFolder();}

        private void CheckForWindowsUpdates_CanExecute(object sender, CanExecuteRoutedEventArgs e) { e.CanExecute = m_supportViewModel.UpdatesAreAvailable(); }
        private void CheckForWindowsUpdates_Executed(object sender, ExecutedRoutedEventArgs e) { m_supportViewModel.CheckForUpdates(); }

        //TODO Check to see if Logos is out of date and if so provide dl link for installer
        private void UpdateSoftware_CanExecute(object sender, CanExecuteRoutedEventArgs e) { }
        private void UpdateSoftware_Executed(object sender, ExecutedRoutedEventArgs e) { }

        public readonly SupportViewModel m_supportViewModel;
    }
}
