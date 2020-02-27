using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
