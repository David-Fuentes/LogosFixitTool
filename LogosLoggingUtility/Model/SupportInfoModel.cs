using LogosLoggingUtility.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosLoggingUtility.Model
{
    public class SupportInfoModel
    {
        public string WindowsVersion { get { return Environment.OSVersion.Version.Build.ToString(); } }
        public string LogosVersion { get { return RegistryHelper.GetInstallVersions().logosVersion; } } 
        public string VerbumVersion { get { return RegistryHelper.GetInstallVersions().verbumVersion; } }
        public string LogosInstallPath { get { return RegistryHelper.GetInstallLocations().logosDirectory; } }
        public string VerbumInstallPath { get { return RegistryHelper.GetInstallLocations().verbumDirectory; } }
        public const string c_Logos = "Logos";
        public const string c_Verbum = "Verbum";
    }
}
