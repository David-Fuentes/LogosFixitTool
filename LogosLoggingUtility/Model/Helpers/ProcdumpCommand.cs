using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosLoggingUtility.Model.Helpers
{
    public static class ProcdumpCommand
    {
        public static string GetCommand(string installPath)
        {
            return $"/c cd {installPath} && procdump -e -g -x . \"{installPath}\\System\\Logos.exe\"";
        }

        public static string GetAltCommand(string installPath)
        {
            return $"/c cd {installPath} && procdump -e 1 -f C0000005 -g -x . \"{installPath}\\System\\Logos.exe\"";

        }
    }
}
