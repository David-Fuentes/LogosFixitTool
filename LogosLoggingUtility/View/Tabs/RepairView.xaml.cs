using LogosLoggingUtility.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace LogosLoggingUtility.View.Tabs
{
    public partial class RepairView : UserControl
    {
        public RepairView(SupportView supportView)
        {
            m_repairViewModel = new RepairViewModel(supportView.m_supportViewModel);
            InitializeComponent();
        }

        private void RepairInstallation_CanExecute(object sender, CanExecuteRoutedEventArgs e) {e.CanExecute = m_repairViewModel.CanFindRepairFile();}
        private void RepairInstallation_Executed(object sender, ExecutedRoutedEventArgs e) {m_repairViewModel.RepairInstallation();}

        private readonly RepairViewModel m_repairViewModel;
    }
}
