using System.ComponentModel;

namespace LogosLoggingUtility.Model.Helpers
{
    public static class InstallVersionHelper
    {
        public const string Logos = "Logos";
        public const string Verbum = "Verbum";
        public static InstallVersion InstallInfo = new InstallVersion();
    }

    public class InstallVersion : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string m_installedVersion = "Logos";

        public string InstalledVersion
        {
            get { return m_installedVersion; }
            set { m_installedVersion = value; OnPropertyChanged("InstalledVersion"); }
        }

        private string m_otherVersion = "Verbum";

        public string OtherVersion
        {
            get { return m_otherVersion; }
            set { m_otherVersion = value; OnPropertyChanged("OtherVersion"); }
        }


    }
}
