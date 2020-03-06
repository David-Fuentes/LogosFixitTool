using LogosLoggingUtility.View.Tabs;
using System.Collections.Generic;
using System.Windows.Controls;

namespace LogosLoggingUtility.Model
{
    public class MainWindowModel
    {
        public MainWindowModel(SupportView supportView, LoggingView loggingView)
        {
            TabControls = new List<UserControl>
            {
                supportView,
                new RepairView(supportView),
                loggingView,
                new TechToolsView(supportView.m_supportViewModel, loggingView.m_loggingViewModel),
                new RemoteView(loggingView)
            };
        }

        public readonly List<string> TabHeaders = new List<string>
        {
            "Support Info",
            "Repair Install",
            "Logging",
            "Tech Tools",
            "Remote Connect"
        };

        public readonly List<UserControl> TabControls;
        public int ActiveTabIndex { get; set; }
    }
}
