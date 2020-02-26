using LogosLoggingUtility.Model;
using LogosLoggingUtility.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LogosLoggingUtility.Controllers
{
    public partial class CardController : UserControl
    {
        public CardController()
        {
            InitializeComponent();
        }

        public void InitializeCardInfo(Card card)
        {
            m_card = card;
            BitmapImage bimage = new BitmapImage();
            bimage.BeginInit();
            bimage.UriSource = new Uri(m_card.IconSource, UriKind.Relative);
            bimage.EndInit();

            CardIcon.Source = bimage;
            this.CardName.Content = m_card.CardHeader;
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            var info = new Window1();
            info.CardFeatureList.ItemsSource = CardManager.CardDescriptionByCardType[m_card.Type].Features;
            info.ShowDialog();
        }

        private Card m_card;
    }
}
