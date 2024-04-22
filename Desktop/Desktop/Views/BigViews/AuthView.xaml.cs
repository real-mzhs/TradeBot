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

namespace Desktop.Views.BigViews
{
    /// <summary>
    /// Interaction logic for AuthView.xaml
    /// </summary>
    public partial class AuthView : UserControl
    {
        public AuthView()
        {
            InitializeComponent();
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderLabel.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.SecurePassword.Length == 0)
            {
                PlaceholderLabel.Visibility = Visibility.Visible;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }

            PlaceholderLabel.Visibility = PasswordBox.SecurePassword.Length > 0 ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
