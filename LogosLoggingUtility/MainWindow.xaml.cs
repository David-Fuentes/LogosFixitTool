using LogosLoggingUtility.Controllers;
using LogosLoggingUtility.Model.Cards;
using LogosLoggingUtility.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace LogosLoggingUtility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var result = FilePathHelper.LocateLogosFolders();

            var cardByCardType = CardManager.GetCardByCardType();
            this.Support.InitializeCardInfo(cardByCardType[Model.CardType.Support]);
            this.RepairCard.InitializeCardInfo(cardByCardType[Model.CardType.Repair]);
            this.LogCard.InitializeCardInfo(cardByCardType[Model.CardType.Logs]);
            this.TechCard.InitializeCardInfo(cardByCardType[Model.CardType.Tech]);
            this.RemoteCard.InitializeCardInfo(cardByCardType[Model.CardType.Remote]);
        }

        //public static void Bttn_Logs_Click()
        //{
        //    ArchiveLogsToDesktop(m_FaithlifeFilePath);
        //}

        


        

        //private void BttnFindFilePath_Click(object sender, RoutedEventArgs e)
        //{
        //    var result = SupportCard.SetLogosFilePath(sender, e);
        //    if (result != "")
        //    {
        //        InstallFilePath.SubText = result;
        //        InstallFilePath.ActionButtonVisibility = Visibility.Collapsed;
        //    }
        //}

        private void BttnLogosFilePath_Click(object sender, RoutedEventArgs e)
        {
            SupportCard.OpenLogosFilePath(sender, e);
        }

        private void BttnLogsFilePath_Click(object sender, RoutedEventArgs e)
        {
            SupportCard.OpenLogsFilePath(sender, e);
        }

        private string m_FaithlifeFilePath;
        private string m_LogosFilePath;
        private bool m_isLogos4Directory;

        
    }
}
