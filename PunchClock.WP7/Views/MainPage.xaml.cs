using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PunchClock.WP7.Business;
using Telerik.Windows.Controls;

namespace PunchClock.WP7
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            RadDiagnostics radDiagnostics = new RadDiagnostics();
            radDiagnostics.EmailTo = "support@adambenoit.com";
            radDiagnostics.ApplicationName = "PunchClock WP7";
            radDiagnostics.ApplicationVersion = "1.0";
            radDiagnostics.ExceptionOccurred += new EventHandler<ExceptionOccurredEventArgs>(RadDiagnostics_ExceptionOccurred);
            radDiagnostics.IncludeScreenshot = true;
            radDiagnostics.Init();



            // Add an Application Bar 
            ApplicationBar = new ApplicationBar();
            ApplicationBar.IsMenuEnabled = true;
            ApplicationBar.IsVisible = true;
            ApplicationBar.Opacity = 1.0;

            ApplicationBarIconButton settingButton = new ApplicationBarIconButton(new Uri("/Images/appbar.feature.settings.rest.png", UriKind.Relative));
            settingButton.Text = "settings";
            settingButton.Click += new EventHandler(settingButton_Click);

            ApplicationBarIconButton helpButton = new ApplicationBarIconButton(new Uri("/Images/appbar.questionmark.rest.png", UriKind.Relative));
            helpButton.Text = "help";
            helpButton.Click += new EventHandler(helpButton_Click);

            ApplicationBar.Buttons.Add(settingButton);
            ApplicationBar.Buttons.Add(helpButton);
        }

        void settingButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Settings.xaml", UriKind.Relative));
        }
        void helpButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Help.xaml", UriKind.Relative));        
        }

        private void RadDiagnostics_ExceptionOccurred(object sender, ExceptionOccurredEventArgs e)
        {
            //e.Cancel = true; setting Cancel to true will prevent the message box from displaying. 
        }

        private void DayStartButton_Click(object sender, RoutedEventArgs e)
        {
            SendEmail email = new SendEmail(PunchTypes.DayStart);
        }

        private void LunchStartButton_Click(object sender, RoutedEventArgs e)
        {
            SendEmail email = new SendEmail(PunchTypes.LunchStart);
        }

        private void LunchEndButton_Click(object sender, RoutedEventArgs e)
        {
            SendEmail email = new SendEmail(PunchTypes.LunchEnd);
        }

        private void DayEndButton_Click(object sender, RoutedEventArgs e)
        {
            SendEmail email = new SendEmail(PunchTypes.DayEnd);
        }
    }
}
