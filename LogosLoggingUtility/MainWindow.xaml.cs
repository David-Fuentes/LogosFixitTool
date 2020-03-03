using LogosLoggingUtility.Model.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace LogosLoggingUtility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            Tabs.SelectionChanged += Tabs_SelectionChanged;

            m_tabManager = new TabManager(Grid_Support);
            InitializeTabManager();
        }

        private void InitializeTabManager()
        {
            m_tabManager.TabContentByTabIndex.Add(0, Grid_Support);
            m_tabManager.TabContentByTabIndex.Add(1, Grid_Repair);
            m_tabManager.TabContentByTabIndex.Add(2, Grid_Resources);
            m_tabManager.TabContentByTabIndex.Add(3, Grid_Logging);
            m_tabManager.TabContentByTabIndex.Add(4, Grid_TechTools);
            m_tabManager.TabContentByTabIndex.Add(5, Grid_Firewall);
            m_tabManager.TabContentByTabIndex.Add(6, Grid_Permissions);
            m_tabManager.TabContentByTabIndex.Add(7, Grid_NET);
            m_tabManager.TabContentByTabIndex.Add(8, Grid_Remote);
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_tabManager.UpdateTabContentVisibility(Tabs.SelectedIndex);
        }

        private TabManager m_tabManager;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
