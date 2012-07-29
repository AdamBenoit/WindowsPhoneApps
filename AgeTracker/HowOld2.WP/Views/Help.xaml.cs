using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace AgeTracker.WP.Views
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
            supportemail.Subject = "Support question about Age Tracker";
            supportemail.Show();
        }
    }
}