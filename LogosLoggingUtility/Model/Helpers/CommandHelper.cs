namespace LogosLoggingUtility.Model.Helpers
{
    public static class CommandHelper
    {
        public static string GetProcdumpCommand(string installPath)
        {
            return $"/c cd {installPath} && procdump -e -g -x . \"{installPath}\\System\\Logos.exe\"";
        }

        public static string GetAltProcdumpCommand(string installPath)
        {
            return $"/c cd {installPath} && procdump -e 1 -f C0000005 -g -x . \"{installPath}\\System\\Logos.exe\"";
        }

        public static string BitsCommand = "/c BITSADMIN /LIST";
        public static string BitsReset = "/c BITSADMIN /RESET";
    }
}
