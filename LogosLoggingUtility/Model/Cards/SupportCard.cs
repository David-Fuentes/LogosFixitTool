using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LogosLoggingUtility.Model.Cards
{
    public static class SupportCard
    {
        public static void CheckForWindowsUpdates(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("Checking for Updates");
        }

        public static void DownloadLogosUpdates(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("Downloading Logos Updates");
        }
        public static void OpenLogosFilePath(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("Opening Logos File Path");
        }
        public static void OpenLogsFilePath(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("Opening Logs File Path");
        }

    }


}
