using LogosLoggingUtility.Model.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace LogosLoggingUtility.View
{
    /// <summary>
    /// Interaction logic for FilePathDisplay.xaml
    /// </summary>
    public partial class FilePathDisplay : UserControl
    {
        //public FilePathDisplay()
        //{
        //    InitializeComponent();
        //}

        //private void Bttn_OpenFileLocation_Click(object sender, RoutedEventArgs e)
        //{
        //    FilePathHelper.OpenFileExplorerToPath(FilePath.Text.ToString());
        //}

        //private void Bttn_FindFileLocation_Click(object sender, RoutedEventArgs e)
        //{
        //    var result = FilePathHelper.SetNewFilePath();
        //    if (!string.IsNullOrEmpty(result) && RepairTab.IsValidRepairPath(result).isValid)
        //    {
        //        SetPathHeader(result);
        //        Bttn_OpenFileLocation.Visibility = Visibility.Visible;
        //        LoggingEventHelper.RaiseFilePathChangedEvent(this, (result, true), Type);
        //    }
        //    else if(!string.IsNullOrEmpty(result))
        //    {
        //        SetPathHeader("Unable to find Logos or Verbum in selected folder.", false);
        //        LoggingEventHelper.RaiseFilePathChangedEvent(this, (result, false), Type);
        //        Bttn_OpenFileLocation.Visibility = Visibility.Hidden;
        //    }
        //}

        //public void SetFileHeader(string newHeader)
        //{
        //    FileHeader.Content = newHeader;
        //}

        //public void SetPathHeader(string header, bool isFound = true)
        //{
        //    FilePath.Text = header;
        //    FilePath.Foreground = isFound ? TextColorHelper.s_plainTextColor : TextColorHelper.s_errorTextColor;
        //    Bttn_OpenFileLocation.Visibility = isFound ? Visibility.Visible : Visibility.Hidden;
        //}

    }
}
