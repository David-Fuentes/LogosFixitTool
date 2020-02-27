using LogosLoggingUtility.Model.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LogosLoggingUtility.Model.Cards
{
    public static class RepairCard
    {
        public enum FileType
        {
            Verbum,
            Logos,
            Log,
            Invalid
        }

        public static (bool isValid, RepairCard.FileType type) IsValidRepairPath(string basePath)
        {
            var isValid = false;
            var installType = RepairCard.FileType.Invalid;

            if (File.Exists(basePath + @"\Install\Installers\Logos4Prerequisites.msi") || File.Exists(basePath + @"\Install\Installers\Logos-x64.msi"))
            {
                isValid = true;
                installType = FileType.Logos;
            }
            else if(File.Exists(basePath + @"\Install\Installers\Verbum-x64.msi"))
            {
                isValid = true;
                installType = FileType.Verbum;
            }
            return (isValid, installType);
        }

        public static void RepairInstallation(FileType type)
        {
            var result = FilePathHelper.LocateLogosFolders();

            var msiPath = type == FileType.Logos
                ? FilePathHelper.s_logosDefaultFilePath + @"\Install\Installers\" + (result.logos4WasFound ? @"Logos4Prerequisites.msi" : @"Logos-x64.msi")
                : FilePathHelper.s_verbumDefaultFilePath + @"\Install\Installers\Verbum-x64.msi";

            RepairInstallationFromMsiFile(msiPath);
        }

        public static void RepairInstallation(string path)
        {
            var logosMsiPath = path + @"\Install\Installers\Logos-x64.msi";
            var verbumMsiPath = path + @"\Install\Installers\Verbum-x64.msi";
            var logosLegacyMsiPath = path + @"\Install\Installers\Logos4Prerequisites.msi";

            if (File.Exists(logosLegacyMsiPath))
                RepairInstallationFromMsiFile(logosLegacyMsiPath);
            if (File.Exists(logosMsiPath))
                RepairInstallationFromMsiFile(logosMsiPath);
            if (File.Exists(verbumMsiPath))
                RepairInstallationFromMsiFile(verbumMsiPath);
        }

        private static void RepairInstallationFromMsiFile(string msiPath)
        {
            try
            {
                Process.Start(msiPath);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unable to open repair file: {e}");
            }
        }
       
    }
}
