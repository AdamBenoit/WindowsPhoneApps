using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace StaticPositionSizeCalculator.WP
{
    public partial class Help : PhoneApplicationPage
    {
        public Help()
        {
            InitializeComponent();
        }

        private void HyperlinkButton1Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask supportemail = new EmailComposeTask();
            supportemail.To = "support@adambenoit.com";
            supportemail.Subject = "Support question about Static Position Size Calculator";
            supportemail.Show();
        }
    }
}