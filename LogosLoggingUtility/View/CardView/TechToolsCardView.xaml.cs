using LogosLoggingUtility.Model.Cards;
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
