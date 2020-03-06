using LogosLoggingUtility.Model.Helpers;

namespace LogosLoggingUtility.Model
{
    public class LoggingModel
    {
        public string IsLoggingEnabled { get { return RegistryHelper.GetLoggingKeyValue() == "1" ? "Enabled" : "Disabled"; } }
        public string ExportFilePath { get; set; }
    }
}
