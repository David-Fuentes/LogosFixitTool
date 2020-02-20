using LogosLoggingUtility.Model.Cards;
using LogosLoggingUtility.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogosLoggingUtility.View
{
    /// <summary>
    /// Interaction logic for FilePathDisplay.xaml
    /// </summary>
    public partial class FilePathDisplay : UserControl
    {
        public FilePathDisplay()
        {
            InitializeComponent();
        }

        private void Bttn_OpenFileLocation_Click(object sender, RoutedEventArgs e)
        {
            FilePathHelper.OpenFileExplorerToPath(FilePath.Content.ToString());
        }

        private void Bttn_FindFileLocation_Click(object sender, RoutedEventArgs e)
        {
            var result = FilePathHelper.SetFilePath();
            if (!string.IsNullOrEmpty(result) && RepairCard.IsValidRepairPath(result))
            {
                SetPathHeader(result);
                LoggingEventHelper.RaiseFilePathChangedEvent(this, result, Type);
            }
            else
            {
                SetPathHeader("Unable to find Logos or Verbum in selected folder.", false);
            }
        }

        public void SetFileHeader(string newHeader)
        {
            FileHeader.Content = newHeader;
        }

        public void SetPathHeader(string header, bool isFound = true)
        {
            FilePath.Content = header;
            FilePath.Foreground = isFound ? TextColorHelper.s_plainTextColor : TextColorHelper.s_errorTextColor;
        }

        public void SetType(RepairCard.FileType type)
        {
            Type = type;
        }

        public RepairCard.FileType Type;
    }
}
