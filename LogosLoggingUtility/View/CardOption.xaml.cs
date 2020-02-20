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

namespace LogosLoggingUtility.View
{
    /// <summary>
    /// Interaction logic for CardOption.xaml
    /// </summary>
    public partial class CardOption : UserControl
    {
        public CardOption()
        {
            InitializeComponent();
        }

        public void SetVisibility( Visibility visibility)
        {
            ActionButtonVisibility = visibility;
        }

        public void SetSubText(string newText, bool isError = false)
        {
            OptionSubtext.Content = newText;
            OptionSubtext.Foreground = isError ? TextColorHelper.s_errorTextColor : TextColorHelper.s_plainTextColor;
        }

        public object ActionButton
        {
            get { return (object)GetValue(ActionButtonProperty); }
            set { SetValue(ActionButtonProperty, value); }
        }

        public object ActionButtonVisibility
        {
            get { return (object)GetValue(ActionButtonVisibilityProperty); }
            set { SetValue(ActionButtonVisibilityProperty, value); }
        }

        public static readonly DependencyProperty ActionButtonProperty = DependencyProperty.Register("ActionButton", typeof(object), typeof(CardOption), new PropertyMetadata(0));
        public static readonly DependencyProperty ActionButtonVisibilityProperty = DependencyProperty.Register("ActionButtonVisibility", typeof(object), typeof(CardOption), new PropertyMetadata(0));

    }
}
