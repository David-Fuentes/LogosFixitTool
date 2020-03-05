using LogosLoggingUtility.Model;
using LogosLoggingUtility.Model.Helpers;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;
using WUApiLib;
using MessageBox = System.Windows.Forms.MessageBox;

namespace LogosLoggingUtility.Controllers
{
    public class SupportViewModel : INPCBase
    {

        public SupportViewModel()
        {
            m_supportModel = new SupportInfoModel();
            PreferredSoftware = SupportInfoModel.c_Logos;
            OtherSoftware = SupportInfoModel.c_Verbum;
            InstalledVersionNumber = m_supportModel.LogosVersion ?? "No version detected.";
            FilePath = m_supportModel.LogosInstallPath ?? "Unable to find file path.";
            WindowsVersion = m_supportModel.WindowsVersion;
            m_softwareFound = !string.IsNullOrEmpty(m_supportModel.LogosVersion);
        }

        public string GetFilePath()
        {
            var result = RegistryHelper.GetInstallLocations();
            if (InstallVersionHelper.InstallInfo.InstalledVersion == InstallVersionHelper.Logos)
            {
                return result.logosDirectory;
            }
            else
                return result.verbumDirectory;
        }

        internal bool UpdatesAreAvailable()
        {
            return true;
        }

        internal void CheckForUpdates()
        {
            var uSession = new UpdateSession();
            var uSearcher = uSession.CreateUpdateSearcher();
            uSearcher.Online = false;
            try
            {
                var sResult = uSearcher.Search("IsInstalled=0 And IsHidden=0");
                Console.WriteLine("Found " + sResult.Updates.Count + " updates" + Environment.NewLine);
                foreach (IUpdate update in sResult.Updates)
                {
                    Console.WriteLine(update.Title);
                }
                MessageBox.Show("Updates were found! Please install them now.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }

        internal bool CanSwitchSoftware()
        {
            return true;
        }

        internal void ChangePreferredSoftware()
        {
            var isUpdatingToLogos = PreferredSoftware == SupportInfoModel.c_Verbum;

            PreferredSoftware = isUpdatingToLogos ? SupportInfoModel.c_Logos : SupportInfoModel.c_Verbum;
            OtherSoftware = isUpdatingToLogos ? SupportInfoModel.c_Verbum : SupportInfoModel.c_Logos;
            InstalledVersionNumber = isUpdatingToLogos ?
                m_supportModel.LogosVersion ?? c_noVersion :
                m_supportModel.VerbumVersion ?? c_noVersion;

            FilePath = isUpdatingToLogos ?
                m_supportModel.LogosInstallPath ?? c_noFilePath :
                m_supportModel.VerbumInstallPath ?? c_noFilePath;

            m_softwareFound = isUpdatingToLogos ? m_supportModel.LogosInstallPath != null : m_supportModel.VerbumInstallPath != null;
        }

        internal bool CanOpenSoftware()
        {
            return m_softwareFound;
        }

        internal void OpenFolder()
        {
            var isLogos = PreferredSoftware == SupportInfoModel.c_Logos;
            FilePathHelper.OpenFileExplorerToPath(isLogos ? m_supportModel.LogosInstallPath : m_supportModel.VerbumInstallPath);
        }

        internal void OpenSoftware()
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

        //Binding Properties
        private string m_preferredSoftware;
        public string PreferredSoftware
        {
            get { return m_preferredSoftware; }
            set { m_preferredSoftware = value; OnPropertyChanged("PreferredSoftware"); }
        }

        private string m_otherSoftware = "Verbum";
        public string OtherSoftware
        {
            get { return m_otherSoftware; }
            set { m_otherSoftware = value; OnPropertyChanged("OtherSoftware"); }
        }

        private string m_installedVersionNumber;
        public string InstalledVersionNumber
        {
            get { return m_installedVersionNumber; }
            set { m_installedVersionNumber = value; OnPropertyChanged("InstalledVersionNumber"); }
        }

        private string m_filePath;
        public string FilePath
        {
            get { return m_filePath; }
            set { m_filePath = value; OnPropertyChanged("FilePath"); }
        }

        private string m_windowsVersion;
        public string WindowsVersion
        {
            get { return m_windowsVersion; }
            set { m_windowsVersion = value; OnPropertyChanged("WindowsVersion"); }
        }

        private bool m_softwareFound;
        public bool SoftwareFound
        {   
            get { return m_softwareFound; }
            set { m_softwareFound = value; OnPropertyChanged("SoftwareFound"); }
        }


        //References
        private readonly SupportInfoModel m_supportModel;
        private const string c_noVersion = "No version detected.";
        private const string c_noFilePath = "Update to detect file path.";
    }
}
