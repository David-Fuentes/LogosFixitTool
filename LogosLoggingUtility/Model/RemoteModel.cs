
using LogosLoggingUtility.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosLoggingUtility.Model
{
    public class RemoteModel
    {
        public RemoteModel(LoggingViewModel viewModel)
        {
            DownloadLocation = viewModel.ExportPath + @"\TeamViewerQS.exe";
        }

        public readonly string TeamviewerDownloadUrl = "https://www.logos.com/media/tech/TeamViewer_QS/TeamViewerQS.exe";
        public readonly string DownloadLocation;
    }
}
