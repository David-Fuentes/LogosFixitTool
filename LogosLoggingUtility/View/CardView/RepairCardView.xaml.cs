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

namespace LogosLoggingUtility.View.CardView
{
    /// <summary>
    /// Interaction logic for RepairCardView.xaml
    /// </summary>
    public partial class RepairCardView : UserControl
    {
        public RepairCardView()
        {
            InitializeComponent();
            m_SelectedLogosRepairPath = null;
            m_SelectedVerbumRepairPath = null;

            LoggingEventHelper.OnFilePathChanged += OnFilePathUpdated;
            var result = FilePathHelper.LocateLogosFolders();
            Bttn_RepairLogos.IsEnabled = result.logosWasFound || result.logos4WasFound;
            Bttn_RepairVerbum.IsEnabled = result.verbumWasFound;
        }

        private void OnFilePathUpdated(object sender, PathUpdateEventArgs e)
        {
            Console.WriteLine($"File Path Updated. Sent from {sender}. Updated to {e.UpdatedPath}");
            
            if (e.FileType == RepairCard.FileType.Logos)
            {
                m_SelectedLogosRepairPath = e.UpdatedPath;
                Bttn_RepairLogos.IsEnabled = true;
            }
            else if (e.FileType == RepairCard.FileType.Verbum)
            {
                m_SelectedVerbumRepairPath = e.UpdatedPath;
                Bttn_RepairVerbum.IsEnabled = true;
            }
        }

        private void Bttn_RepairLogos_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).CommandParameter.ToString() == "Logos")
            {
                if (string.IsNullOrEmpty(m_SelectedLogosRepairPath))
                    RepairCard.RepairInstallation(RepairCard.FileType.Logos);
                else
                    RepairCard.RepairInstallation(m_SelectedLogosRepairPath);
            }
            else if (((Button)sender).CommandParameter.ToString() == "Verbum")
                if (string.IsNullOrEmpty(m_SelectedVerbumRepairPath))
                    RepairCard.RepairInstallation(RepairCard.FileType.Verbum);
                else
                    RepairCard.RepairInstallation(m_SelectedVerbumRepairPath);

        }

        private string m_SelectedLogosRepairPath;
        private string m_SelectedVerbumRepairPath;
    }
}
