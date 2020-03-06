using System.Diagnostics;

namespace LogosLoggingUtility.Model.Helpers
{
    public static class ProcessHelper
    {
        public static bool LogosOrVerbumIsOpen()
        {
            return Process.GetProcessesByName("Logos").Length > 0 || Process.GetProcessesByName("Verbum").Length > 0;
        }
    }
}
