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

            var cardByCardType = CardManager.GetCardByCardType();
            this.Support.InitializeCardInfo(cardByCardType[Model.CardType.Support]);
            this.RepairCard.InitializeCardInfo(cardByCardType[Model.CardType.Repair]);
            this.LogCard.InitializeCardInfo(cardByCardType[Model.CardType.Logs]);
            this.TechCard.InitializeCardInfo(cardByCardType[Model.CardType.Tech]);
            this.RemoteCard.InitializeCardInfo(cardByCardType[Model.CardType.Remote]);
        }
    }
}
