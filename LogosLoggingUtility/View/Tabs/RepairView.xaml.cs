using LogosLoggingUtility.Controllers;
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
    /// Interaction logic for RepairView.xaml
    /// </summary>
    public partial class RepairView : UserControl
    {
        public RepairView(SupportView supportView)
        {
            m_repairViewModel = new RepairViewModel(supportView.m_supportViewModel);
            InitializeComponent();
        }

        private void RepairInstallation_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = m_repairViewModel.CanFindRepairFile();
        }
        private void RepairInstallation_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            m_repairViewModel.RepairInstallation();
        }

        private readonly RepairViewModel m_repairViewModel;
    }
}
