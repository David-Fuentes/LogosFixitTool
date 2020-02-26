using LogosLoggingUtility.Controllers;
using LogosLoggingUtility.Model;
using System.Collections.Generic;
using System.Windows;

namespace LogosLoggingUtility.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            CardFeatureList.ItemsSource = new List<Feature>();
        }

        public void SetInfo(Card card)
        {
            CardHeader.Content = card.CardHeader;
            var cardDescription = CardManager.CardDescriptionByCardType[card.Type];
            CardFeatureList.ItemsSource = cardDescription.Features;
            CardFeatureList.Items.Refresh();
        }
    }
}
