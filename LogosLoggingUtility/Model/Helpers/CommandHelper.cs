namespace LogosLoggingUtility.Model.Helpers
{
    public static class CommandHelper
    {
        public static string GetProcdumpCommand(string installPath, Cards.RepairCard.FileType type)
        {
            var processName = type == Cards.RepairCard.FileType.Logos ? "Logos.exe" : "Verbum.exe";
            return $"/c cd {installPath} && procdump -e -g -x . \"{installPath}\\System\\{processName}\"";
        }

        public static string GetAltProcdumpCommand(string installPath, Cards.RepairCard.FileType type)
        {
            var processName = type == Cards.RepairCard.FileType.Logos ? "Logos.exe" : "Verbum.exe";
            return $"/c cd {installPath} && procdump -e 1 -f C0000005 -g -x . \"{installPath}\\System\\{processName}\"";
        }

        public static string BitsCommand = "/c BITSADMIN /LIST";
        public static string BitsReset = "/c BITSADMIN /RESET";
    }
}
