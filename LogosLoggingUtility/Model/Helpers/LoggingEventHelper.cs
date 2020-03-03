using System;
using System.Diagnostics;

namespace LogosLoggingUtility.Model.Helpers
{
    public static class LoggingEventHelper
    {
        public static event EventHandler<PathUpdateEventArgs> OnFilePathChanged;
        public static event EventHandler<EventArgs> OnDownloadFinished;

        public static void RaiseFilePathChangedEvent(object sender, (string newPath, bool validPath) result)
        {
            OnFilePathChanged(sender, new PathUpdateEventArgs(result.newPath, result.validPath));
        }

        public static void RaiseDownloadFinishedEvent(object sender, EventArgs e)
        {
            OnDownloadFinished(sender, e);
        }

    }

    public class PathUpdateEventArgs : EventArgs
    {
        public PathUpdateEventArgs(string path, bool valid)
        {
            UpdatedPath = path;
            IsValidPath = valid;
        }
        public string UpdatedPath { get; set; }
        public bool IsValidPath { get; set; }
    }
}
