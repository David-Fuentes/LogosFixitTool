using LogosLoggingUtility.View.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LogosLoggingUtility.Model
{
    public class MainWindowModel
    {
        public MainWindowModel(SupportView supportView)
        {
            TabControls = new List<UserControl>
            {
                supportView,
                new RepairView(supportView),
                new LoggingView()
            };
        }

        public readonly List<string> TabHeaders = new List<string>
        {
            "Support Info",
            "Repair Install",
            "Logging",
            "Tech Tools",
            "Firewall",
            "Permissions",
            "Repair .NET",
            "Remote Connect"
        };

        public readonly List<UserControl> TabControls;
        public int ActiveTabIndex { get; set; }
    }
}
