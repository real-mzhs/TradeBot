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
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
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


        private void ConfirmPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ConfirmPasswordPlaceholderLabel.Visibility = Visibility.Collapsed;
        }

        private void ConfirmPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ConfirmPasswordBox.SecurePassword.Length == 0)
            {
                ConfirmPasswordPlaceholderLabel.Visibility = Visibility.Visible;
            }
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).ConfirmPassword = ((PasswordBox)sender).Password;
            }

            ConfirmPasswordPlaceholderLabel.Visibility = ((PasswordBox)sender).Password.Length > 0 ? Visibility.Collapsed : Visibility.Visible;
        }



    }
}
