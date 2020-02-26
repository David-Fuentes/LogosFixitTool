using LogosLoggingUtility.Controllers;
using System.Windows;

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

            var cardByCardType = CardManager.GetCardInfoByCardType();
            this.Support.InitializeCardInfo(cardByCardType[Model.CardType.Support]);
            this.RepairCard.InitializeCardInfo(cardByCardType[Model.CardType.Repair]);
            this.LogCard.InitializeCardInfo(cardByCardType[Model.CardType.Logs]);
            this.TechCard.InitializeCardInfo(cardByCardType[Model.CardType.Tech]);
            this.RemoteCard.InitializeCardInfo(cardByCardType[Model.CardType.Remote]);
        }
    }
}
