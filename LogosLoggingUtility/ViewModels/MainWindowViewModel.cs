﻿using LogosLoggingUtility.Model;
using LogosLoggingUtility.View.Tabs;
using System.Collections.Generic;
using System.Windows.Controls;

namespace LogosLoggingUtility.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            var supportView = new SupportView();
            var loggingView = new LoggingView();
            m_mainWindowModel = new MainWindowModel(supportView, loggingView);
            ActiveControl = m_mainWindowModel.TabControls[0];
            Tabs = m_mainWindowModel.TabHeaders;
        }

        internal void UpdateActiveTab(int selectedIndex)
        {
            ActiveControl = m_mainWindowModel.TabControls[selectedIndex];
        }

        private UserControl m_activeControl;
        public UserControl ActiveControl
        {
            get { return m_activeControl; }
            set { m_activeControl = value; OnPropertyChanged("ActiveControl"); }
        }

        private List<string> m_tabs;
        public List<string> Tabs
        {
            get { return m_tabs; }
            set { m_tabs = value; OnPropertyChanged("Tabs"); }
        }

        private readonly MainWindowModel m_mainWindowModel;

        
    }
}
