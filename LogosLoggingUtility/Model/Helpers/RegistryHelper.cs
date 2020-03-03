using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosLoggingUtility.Model.Helpers
{
    public static class RegistryHelper
    {
        public static (string logosDirectory, string verbumDirectory) GetInstallLocations()
        {
            var result = GetKeyValues(installKey);
            return (result.logosValue, result.verbumValue);
        }

        

        public static (string logosVersion, string verbumVersion) GetInstallVersions()
        {
            var result = GetKeyValues(versionKey);
            return (result.logosValue, result.verbumValue);
        }

        private static (string logosValue, string verbumValue) GetKeyValues(string key)
        {
            var logosKey = Registry.CurrentUser.OpenSubKey(logosRegistryPath);
            var verbumKey = Registry.CurrentUser.OpenSubKey(verbumRegistryPath);
            var logosValue = logosKey != null ? logosKey.GetValue(key).ToString() : null;
            var verbumValue = verbumKey != null ? verbumKey.GetValue(key).ToString() : null;
            return (logosValue, verbumValue);
        }

        private const string logosRegistryPath = @"Software\Logos4";
        private const string verbumRegistryPath = @"Software\Verbum";
        private const string installKey = @"InstallDirectory";
        private const string versionKey = @"InstalledVersion";
    }
}
