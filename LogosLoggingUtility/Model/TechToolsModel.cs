using LogosLoggingUtility.ViewModels;
using System;

namespace LogosLoggingUtility.Model
{
    public class TechToolsModel
    {
        public TechToolsModel(LoggingViewModel viewModel)
        {
            ProcdumpPath = viewModel.ExportPath + @"\Prodcump.zip";
        }

        public string EventViewerPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\eventvwr";
        public string CmdPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\cmd";
        public string BitsCommand = "/c BITSADMIN /LIST";
        public string BitsReset = "/c BITSADMIN /RESET";
        public string ProcdumpPath;
    }
}
