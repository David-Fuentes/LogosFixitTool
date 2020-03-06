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
            var result = GetKeyValues(m_installKey);
            return (result.logosValue, result.verbumValue);
        }

        public static string GetLoggingKeyValue()
        {
            return Registry.CurrentUser.OpenSubKey(m_loggingPath).GetValue("Enabled")?.ToString();
        }

        public static (string logosVersion, string verbumVersion) GetInstallVersions()
        {
            var result = GetKeyValues(m_versionKey);
            return (result.logosValue, result.verbumValue);
        }

        private static (string logosValue, string verbumValue) GetKeyValues(string key)
        {
            var logosKey = Registry.CurrentUser.OpenSubKey(m_logosRegistryPath);
            var verbumKey = Registry.CurrentUser.OpenSubKey(m_verbumRegistryPath);
            var logosValue = logosKey != null ? logosKey.GetValue(key).ToString() : null;
            var verbumValue = verbumKey != null ? verbumKey.GetValue(key).ToString() : null;
            return (logosValue, verbumValue);
        }

        public static void SetLoggingValue(bool value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Logos4\Logging"))
            {
                key.SetValue("Enabled", value ? 1 : 0);
            }
        }

        private const string m_logosRegistryPath = @"Software\Logos4";
        private const string m_verbumRegistryPath = @"Software\Verbum";
        private const string m_loggingPath = @"Software\Logos4\Logging";
        private const string m_installKey = @"InstallDirectory";
        private const string m_versionKey = @"InstalledVersion";
    }
}
