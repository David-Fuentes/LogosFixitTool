using LogosLoggingUtility.Model.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogosLoggingUtility.Model.Helpers
{
    public static class LoggingEventHelper
    {
        public static event EventHandler<PathUpdateEventArgs> OnFilePathChanged;
        public static event EventHandler<EventArgs> OnDownloadFinished;

        public static void RaiseFilePathChangedEvent(object sender, string newPath, RepairCard.FileType type)
        {
            OnFilePathChanged(sender, new PathUpdateEventArgs(newPath, type));
            Console.WriteLine("File path event has been raised");
        }

        public static void RaiseDownloadFinishedEvent(object sender, EventArgs e)
        {
            OnDownloadFinished(sender, e);
        }
    }

    public class PathUpdateEventArgs : EventArgs
    {
        public PathUpdateEventArgs(string path, RepairCard.FileType type)
        {
            UpdatedPath = path;
            FileType = type;
        }
        public string UpdatedPath { get; set; }
        public RepairCard.FileType FileType { get; set; }
    }
}
