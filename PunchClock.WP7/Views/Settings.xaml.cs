using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using PunchClock.WP7.Business;

namespace PunchClock.WP7.Views
{
    public partial class Settings : PhoneApplicationPage
    {
        public AppSettings settings = new AppSettings();
        public Settings()
        {
            InitializeComponent();
            // Add an Application Bar that has a 'done' confirmation button and 
            // a 'cancel' button

            ApplicationBar = new ApplicationBar();
            ApplicationBar.IsMenuEnabled = true;
            ApplicationBar.IsVisible = true;
            ApplicationBar.Opacity = 1.0;

            ApplicationBarIconButton doneButton = new ApplicationBarIconButton(new Uri("/Images/appbar.check.rest.png", UriKind.Relative));
            doneButton.Text = "done";
            doneButton.Click += new EventHandler(doneButton_Click);

            ApplicationBarIconButton cancelButton = new ApplicationBarIconButton(new Uri("/Images/appbar.Close.rest.png", UriKind.Relative));
            cancelButton.Text = "cancel";
            cancelButton.Click += new EventHandler(cancelButton_Click);

            ApplicationBar.Buttons.Add(doneButton);
            ApplicationBar.Buttons.Add(cancelButton);

            toEmailTextBlock.Text = settings.ToEmailSetting;
            toNameTextBlock.Text = settings.ToNameSetting;
            dayStartTextBox.Text = settings.DayStartSetting;
            lunchStartTextBox.Text = settings.LunchStartSetting;
            lunchEndTextBox.Text = settings.LunchEndSetting;
            dayEndTextBox.Text = settings.DayEndSetting;


        }

        void doneButton_Click(object sender, EventArgs e)
        {
            try
            {
                settings.ToEmailSetting = toEmailTextBlock.Text;
                settings.ToNameSetting = toNameTextBlock.Text;
                settings.DayStartSetting = dayStartTextBox.Text;
                settings.LunchStartSetting = lunchStartTextBox.Text;
                settings.LunchEndSetting = lunchEndTextBox.Text;
                settings.DayEndSetting = dayEndTextBox.Text;
                
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBoxResult result =
                    MessageBox.Show(
                        "There was a problem Saving, please try again. If the problem continues, please report the problem by choosing 'Cancel' and saying yes to the next message..",
                        "Error", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.Cancel)
                {
                    throw ex;
                }
                else if (result == MessageBoxResult.OK)
                {

                }
            }
        }

        void cancelButton_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void selectContactButton_Click(object sender, EventArgs e)
        {
            try
            {
                EmailAddressChooserTask emailAddressChooserTask = new EmailAddressChooserTask();
                emailAddressChooserTask.Completed += new EventHandler<EmailResult>(emailAddressChooserTask_Completed);
                emailAddressChooserTask.Show();
            }
            catch (Exception ex)
            {
                
            }
        }

        void emailAddressChooserTask_Completed(object sender, EmailResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                try
                {
                    toNameTextBlock.Text = e.DisplayName;
                    toEmailTextBlock.Text = e.Email;
                }
                catch (Exception ex)
                {
                    
                }
                
            }
        }
    }
}