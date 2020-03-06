using LogosLoggingUtility.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace LogosLoggingUtility
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            m_mainWindowViewModel = new MainWindowViewModel();
            DataContext = m_mainWindowViewModel;
            InitializeComponent();
            Tabs.SelectedItem = Tabs.Items[0];
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_mainWindowViewModel.UpdateActiveTab(Tabs.SelectedIndex);
        }

        private readonly MainWindowViewModel m_mainWindowViewModel;
    }
}
