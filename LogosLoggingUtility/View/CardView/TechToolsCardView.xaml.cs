using LogosLoggingUtility.Model.Cards;
using System.Windows;
using System.Windows.Controls;

namespace LogosLoggingUtility.View.CardView
{
    /// <summary>
    /// Interaction logic for TechToolsCard.xaml
    /// </summary>
    public partial class TechToolsCardView : UserControl
    {
        public TechToolsCardView()
        {
            InitializeComponent();
        }

        private void Bttn_StartEventViewer_Click(object sender, RoutedEventArgs e)
        {
            TechToolsCard.StartEventViewer();
        }

        private void Bttn_GetProcdump_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            TechToolsCard.GetProcdump(e);
        }

        private void Bttn_CorruptResources_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
