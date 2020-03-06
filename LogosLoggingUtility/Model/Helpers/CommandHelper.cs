namespace LogosLoggingUtility.Model.Helpers
{
    public static class CommandHelper
    {
        public static string GetProcdumpCommand(string installPath, string type)
        {
            var processName = type == InstallVersionHelper.Logos ? "Logos.exe" : "Verbum.exe";
            return $"/c cd {installPath} && procdump -e -g -x . \"{installPath}System\\{processName}\"";
        }

        public static string GetAltProcdumpCommand(string installPath, string type)
        {
            var processName = type == InstallVersionHelper.Logos ? "Logos.exe" : "Verbum.exe";
            return $"/c cd {installPath} && procdump -e 1 -f C0000005 -g -x . \"{installPath}System\\{processName}\"";
        }
    }
}
