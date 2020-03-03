using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LogosLoggingUtility.Model.Helpers
{
    public class TabManager
    {
        public TabManager(Grid intitalGrid)
        {
            m_activeTabContainer = intitalGrid;
        }

        public void UpdateTabContentVisibility(int newIndex)
        {
            var previousTabContainer = m_activeTabContainer;
            m_activeTabContainer = TabContentByTabIndex[newIndex];

            previousTabContainer.Visibility = Visibility.Collapsed;
            m_activeTabContainer.Visibility = Visibility.Visible;
        }



        public Dictionary<string, Grid> TabContentByTabHeader = new Dictionary<string, Grid>();
        public Dictionary<int, Grid> TabContentByTabIndex = new Dictionary<int, Grid>();

        private Grid m_activeTabContainer = null;
    }
}
