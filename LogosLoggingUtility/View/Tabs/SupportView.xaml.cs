using LogosLoggingUtility.Controllers;
using LogosLoggingUtility.Model;
using LogosLoggingUtility.Model.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Support.xaml
    /// </summary>
    public partial class SupportView : UserControl
    {
        public SupportView()
        {
            this.DataContext = InstallVersionHelper.InstallInfo;
            InitializeComponent();

            windowsVersionNumber.Content = SupportTab.GetWindowsVersion();
            UpdateVersionNumber();
            UpdateFilePath();
        }

        private void UpdateVersionNumber()
        {
            softwareVersionNumber.Content = SupportTab.GetVersionText();
        }

        private void UpdateFilePath()
        {
            var path = SupportTab.GetFilePath();
            if (!string.IsNullOrEmpty(path))
            {
                filePath.Text = path;
                EnableButtons();
            }
            else
            {
                filePath.Text = $"Unable to find {InstallVersionHelper.InstallInfo.InstalledVersion} file path. Please click `Find`.";
                DisableButtons();
            }
        }

        private void EnableButtons()
        {
            bttn_Open.Visibility = Visibility.Visible;
        }

        private void DisableButtons()
        {
            bttn_Open.Visibility = Visibility.Hidden;
        }

        private void ChangeSoftwareType_Click(object sender, RoutedEventArgs e)
        {
            if (InstallVersionHelper.InstallInfo.InstalledVersion == "Logos")
            {
                InstallVersionHelper.InstallInfo.InstalledVersion = "Verbum";
                InstallVersionHelper.InstallInfo.OtherVersion = "Logos";
            }
            else
            {
                InstallVersionHelper.InstallInfo.InstalledVersion ="Logos";
                InstallVersionHelper.InstallInfo.OtherVersion ="Verbum";
            }
            UpdateFilePath();
            UpdateVersionNumber();
        }

        private void bttn_Find_Click(object sender, RoutedEventArgs e)
        {
            FilePathHelper.SetNewFilePath();
        }

        private void bttn_Open_Click(object sender, RoutedEventArgs e)
        {
            FilePathHelper.OpenFileExplorerToPath(SupportTab.GetFilePath());
        }

        private void bttn_Open_Software_Click(object sender, RoutedEventArgs e)
        {
            SupportTab.OpenSoftware();
        }
    }
}
