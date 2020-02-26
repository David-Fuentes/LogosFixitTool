using LogosLoggingUtility.Model.Helpers;
using System;
using System.Diagnostics;

namespace LogosLoggingUtility.Model.Cards
{
    public static class SupportCard
    {
        public static (string major, string minor) GetLogosVersionNumber()
        {
            var path = FilePathHelper.s_logosDefaultFilePath + @"\Logos.exe";
            var info = FileVersionInfo.GetVersionInfo(path);
            return (info.FileMajorPart.ToString(), info.FileMinorPart.ToString());

        }

        public static string GetWindowsVersion()
        {
            var osVersion = Environment.OSVersion.Version;
            return osVersion.Build.ToString();
        }
    }


}
