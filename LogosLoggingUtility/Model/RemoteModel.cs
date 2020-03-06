
using LogosLoggingUtility.ViewModels;

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
