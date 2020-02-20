using LogosLoggingUtility.Model;
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

namespace LogosLoggingUtility.Controllers
{
    /// <summary>
    /// Interaction logic for CardViewModel.xaml
    /// </summary>
    public partial class CardController : UserControl
    {
        public CardController()
        {
            InitializeComponent();
        }

        public void InitializeCardInfo(Card card)
        {
            var cardIcon = new Image();
            BitmapImage bimage = new BitmapImage();
            bimage.BeginInit();
            bimage.UriSource = new Uri(card.IconSource, UriKind.Relative);
            bimage.EndInit();

            this.CardIcon = cardIcon;
            this.CardName.Content = card.CardHeader;
        }
    }
}
