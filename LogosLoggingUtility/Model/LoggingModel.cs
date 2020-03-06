using LogosLoggingUtility.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosLoggingUtility.Model
{
    public class LoggingModel
    {
        public bool IsLoggingEnabled { get { return RegistryHelper.GetLoggingKeyValue() == "null"; }}
        public string ExportFilePath { get; set; }
    }
}
