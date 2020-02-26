using LogosLoggingUtility.Model.Cards;
using LogosLoggingUtility.Model.Helpers;
using System.Windows.Controls;

namespace LogosLoggingUtility.View.CardView
{
    /// <summary>
    /// Interaction logic for SupportCardView.xaml
    /// </summary>
    public partial class SupportCardView : UserControl
    {
        public SupportCardView()
        {
            InitializeComponent();
            SetCardInfo();
        }

        private void SetCardInfo()
        {
            var result = FilePathHelper.LocateLogosFolders();
            LogosLocation.SetFileHeader("Logos Install Location: ");
            VerbumLocation.SetFileHeader("Verbum Install Location: ");
            LogLocation.SetFileHeader("Log Location: ");

            if (result.logosWasFound)
                LogosLocation.SetPathHeader(FilePathHelper.s_logosDefaultFilePath);
            else if (result.logos4WasFound)
                LogosLocation.SetPathHeader(FilePathHelper.s_logosDefaultFilePath + "4");
            else
                LogosLocation.SetPathHeader("Unable to detect Logos installation, please click 'Change'.", false);

            if (result.verbumWasFound)
                VerbumLocation.SetPathHeader(FilePathHelper.s_verbumDefaultFilePath);
            else
                VerbumLocation.SetPathHeader("Unable to detect Logos installation, please click 'Change'.", false);

            if (result.faithlifeWasFound)
                LogLocation.SetPathHeader(FilePathHelper.s_faithlifeDefaultFilePath);
            else
                LogLocation.SetPathHeader("Unable to find Logging folder, please enable logging and restart Logos.", false);

            var versionInfo = SupportCard.GetLogosVersionNumber();
            LogosVersionNumber.Content = $"{versionInfo.major}.{versionInfo.minor}";

            WindowsVersionNumber.Content = SupportCard.GetWindowsVersion();
        }
    }
}
