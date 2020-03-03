using LogosLoggingUtility.Model;
using LogosLoggingUtility.Model.Helpers;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace LogosLoggingUtility.Controllers
{
    public class SupportTab
    {
        public static string GetVersionText()
        {
            var result = RegistryHelper.GetInstallVersions();
            if (InstallVersionHelper.InstallInfo.InstalledVersion == "Logos")
                return result.logosVersion;
            else
                return result.verbumVersion;
        }

        public static string GetWindowsVersion()
        {
            var osVersion = Environment.OSVersion.Version;
            return osVersion.Build.ToString();
        }

        public static string GetFilePath()
        {
            var result = RegistryHelper.GetInstallLocations();
            if (InstallVersionHelper.InstallInfo.InstalledVersion == InstallVersionHelper.Logos)
            {
                return result.logosDirectory;
            }
            else
                return result.verbumDirectory;
        }

        public static void OpenSoftware()
        {
            try
            {
                using(var process = new Process())
                {
                    var result = RegistryHelper.GetInstallLocations();
                    if (InstallVersionHelper.InstallInfo.InstalledVersion == InstallVersionHelper.Logos && result.logosDirectory != null)
                        process.StartInfo.FileName = result.logosDirectory + "Logos.exe";
                    else if (InstallVersionHelper.InstallInfo.InstalledVersion == InstallVersionHelper.Verbum && result.verbumDirectory != null)
                        process.StartInfo.FileName = result.logosDirectory + "Verbum.exe";
                    process.Start();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unable to start application: \n\n{e}");
            }

        }
    }
}
