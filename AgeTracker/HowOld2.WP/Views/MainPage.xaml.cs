using System;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;
using Itenso.TimePeriod;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Telerik.Windows.Controls;

//https://github.com/danielcrenna
namespace HowOld2.WP.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly AppSettings _appSettings = new AppSettings();

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Add an Application Bar with a 'setting menu item.
            ApplicationBar = new ApplicationBar();
            ApplicationBar.IsMenuEnabled = true;
            ApplicationBar.IsVisible = true;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.Mode = ApplicationBarMode.Minimized;

            var settingsItem = new ApplicationBarIconButton(new Uri("/Images/appbar.feature.settings.rest.png", UriKind.Relative));
            var helpItem = new ApplicationBarIconButton(new Uri("/Images/appbar.questionmark.rest.png", UriKind.Relative));
            var shareItem = new ApplicationBarIconButton(new Uri("/Images/share.png", UriKind.Relative));
            var rateItem = new ApplicationBarIconButton(new Uri("/Images/appbar.favs.rest.png", UriKind.Relative));
            
            settingsItem.Text = "settings";
            helpItem.Text = "help";
            shareItem.Text = "share";
            rateItem.Text = "rate";

            settingsItem.Click += SettingsClick;
            helpItem.Click += HelpClick;
            shareItem.Click += TwitterItemOnClick;
            rateItem.Click += RateItemOnClick;

            ApplicationBar.Buttons.Add(shareItem);
            ApplicationBar.Buttons.Add(settingsItem);
            ApplicationBar.Buttons.Add(helpItem);
            ApplicationBar.Buttons.Add(rateItem);

            Ad1.ApplicationId = "xxxxxx";
            Ad1.AdUnitId = "xxxxxx";
        }
        private void TwitterItemOnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                ShareStatusTask shareStatusTask = new ShareStatusTask();
                string message = string.Empty;
                string name = string.Empty;
                if (MainPagePivot.SelectedIndex == 0)
                {
                    message = CalculateSinceBirth(_appSettings.Birthday1DateSetting,
                                            _appSettings.Birthday1TimeSetting,
                                            _appSettings.UseTime1CheckBoxSetting).GetDescription();
                    name = _appSettings.Birthday1NameSetting;
                }
                else if (MainPagePivot.SelectedIndex == 1)
                {
                    if (_appSettings.UsePerson2CheckBoxSetting)
                    {
                        message = CalculateSinceBirth(_appSettings.Birthday2DateSetting,
                                            _appSettings.Birthday2TimeSetting,
                                            _appSettings.UseTime2CheckBoxSetting).GetDescription();
                        name = _appSettings.Birthday2NameSetting;
                    }
                    else
                    {
                        MessageBox.Show("Please enable this person before trying to share their age.", "Not Enabled.", MessageBoxButton.OK);
                        return;
                    }
                }
                else if (MainPagePivot.SelectedIndex == 2)
                {
                    if (_appSettings.UsePerson3CheckBoxSetting)
                    {
                        message = CalculateSinceBirth(_appSettings.Birthday3DateSetting,
                                            _appSettings.Birthday3TimeSetting,
                                            _appSettings.UseTime3CheckBoxSetting).GetDescription();
                        name = _appSettings.Birthday3NameSetting;
                    }
                    else
                    {
                        MessageBox.Show("Please enable this person before trying to share their age.", "Not Enabled.", MessageBoxButton.OK);
                        return;
                    }
                }
                shareStatusTask.Status = name + " is " + message + " old right now. \n\nSent by the Age Tracker app for Windows Phone.";
                shareStatusTask.Show();
            }
            catch (InvalidOperationException ex)
            {
                
                //throw;
            }
        }
        private void HelpClick(object sender, EventArgs eventArgs)
        {
            NavigationService.Navigate(new Uri("/Views/Help.xaml", UriKind.Relative));
        }
        private void RateItemOnClick(object sender, EventArgs eventArgs)
        {
            MarketplaceReviewTask rate = new MarketplaceReviewTask();
            rate.Show();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Person1PivotItem.Header = _appSettings.Birthday1NameSetting;
            if (_appSettings.UseTime1CheckBoxSetting)
            {
                person1BirthDateTextBlock.Text = _appSettings.Birthday1DateSetting.ToString("dddd, MMMM dd yyyy", CultureInfo.CurrentCulture) + _appSettings.Birthday1TimeSetting.ToString(" hh:mm tt", CultureInfo.CurrentCulture);
            }
            else
            {
                person1BirthDateTextBlock.Text = _appSettings.Birthday1DateSetting.ToString("dddd, MMMM dd yyyy", CultureInfo.CurrentCulture);
            }

            if (_appSettings.UsePerson2CheckBoxSetting)
            {
                Person2PivotItem.Header = _appSettings.Birthday2NameSetting;
                if (_appSettings.UseTime2CheckBoxSetting)
                {
                    person2BirthDateTextBlock.Text = _appSettings.Birthday2DateSetting.ToString("dddd, MMMM dd yyyy", CultureInfo.CurrentCulture) + _appSettings.Birthday2TimeSetting.ToString(" hh:mm tt", CultureInfo.CurrentCulture);
                }
                else
                {
                    person2BirthDateTextBlock.Text = _appSettings.Birthday2DateSetting.ToString("dddd, MMMM dd yyyy", CultureInfo.CurrentCulture);
                }
                SetUIElementVisibility(person2BirthDateTextBlock, true);
                SetUIElementVisibility(textBlock2, false);
                SetUIElementVisibility(Person2Stackpanel, true);
            }
            else
            {
                Person2PivotItem.Header = "Person 2";
                SetUIElementVisibility(person2BirthDateTextBlock, false);
                SetUIElementVisibility(textBlock2, true);
                SetUIElementVisibility(Person2Stackpanel, false);
            }

            if (_appSettings.UsePerson3CheckBoxSetting)
            {
                Person3PivotItem.Header = _appSettings.Birthday3NameSetting;
                if (_appSettings.UseTime3CheckBoxSetting)
                {
                    person3BirthDateTextBlock.Text = _appSettings.Birthday3DateSetting.ToString("dddd, MMMM dd yyyy", CultureInfo.CurrentCulture) + _appSettings.Birthday3TimeSetting.ToString(" hh:mm tt", CultureInfo.CurrentCulture);
                }
                else
                {
                    person3BirthDateTextBlock.Text = _appSettings.Birthday3DateSetting.ToString("dddd, MMMM dd yyyy", CultureInfo.CurrentCulture);
                }
                SetUIElementVisibility(person3BirthDateTextBlock, true);
                SetUIElementVisibility(textBlock3, false);
                SetUIElementVisibility(Person3Stackpanel, true);
            }
            else
            {
                Person3PivotItem.Header = "Person 3";
                SetUIElementVisibility(person3BirthDateTextBlock, true);
                SetUIElementVisibility(textBlock3, true);
                SetUIElementVisibility(Person3Stackpanel, false);
            }

            var tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(1);
            tmr.Tick += OnTimerTick;
            tmr.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            // textBlock1.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            UpdatePerson1UI(CalculateSinceBirth(_appSettings.Birthday1DateSetting, _appSettings.Birthday1TimeSetting,
                                                _appSettings.UseTime1CheckBoxSetting));
            UpdatePerson2UI(CalculateSinceBirth(_appSettings.Birthday2DateSetting, _appSettings.Birthday2TimeSetting,
                                                _appSettings.UseTime2CheckBoxSetting));
            UpdatePerson3UI(CalculateSinceBirth(_appSettings.Birthday3DateSetting, _appSettings.Birthday3TimeSetting,
                                                _appSettings.UseTime3CheckBoxSetting));
        }

        private DateDiff CalculateSinceBirth(DateTime Date, DateTime Time, bool UseTime)
        {
            DateTime Birthday;
            if (UseTime)
            {
                Birthday = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hour, Time.Minute, 0);
            }
            else
            {
                Birthday = new DateTime(Date.Year, Date.Month, Date.Day, 0, 0, 0);
            }

            return new DateDiff(Birthday, DateTime.Now);
        }

        private void UpdatePerson1UI(DateDiff diff)
        {
            Person1YearsTextBlock.Text = diff.Years.ToString(CultureInfo.InvariantCulture);
            Person1MonthsTextBlock.Text = diff.Months.ToString(CultureInfo.InvariantCulture);
            Person1DaysTextBlock.Text = diff.Days.ToString(CultureInfo.InvariantCulture);
            Person1HoursTextBlock.Text = diff.Hours.ToString(CultureInfo.InvariantCulture);
            Person1MinutesTextBlock.Text = diff.Minutes.ToString(CultureInfo.InvariantCulture);
            Person1SecondsTextBlock.Text = diff.Seconds.ToString(CultureInfo.InvariantCulture);

            Person1ElapsedYearsTextBlock.Text = diff.ElapsedYears.ToString(CultureInfo.InvariantCulture);
            Person1ElapsedMonthsTextBlock.Text = diff.ElapsedMonths.ToString(CultureInfo.InvariantCulture);
            Person1ElapsedDaysTextBlock.Text = diff.ElapsedDays.ToString(CultureInfo.InvariantCulture);
            Person1ElapsedHoursTextBlock.Text = diff.ElapsedHours.ToString(CultureInfo.InvariantCulture);
            Person1ElapsedMinutesTextBlock.Text = diff.ElapsedMinutes.ToString(CultureInfo.InvariantCulture);
            Person1ElapsedSecondsTextBlock.Text = diff.ElapsedSeconds.ToString(CultureInfo.InvariantCulture);
        }

        private void UpdatePerson2UI(DateDiff diff)
        {
            Person2YearsTextBlock.Text = diff.Years.ToString(CultureInfo.InvariantCulture);
            Person2MonthsTextBlock.Text = diff.Months.ToString(CultureInfo.InvariantCulture);
            Person2DaysTextBlock.Text = diff.Days.ToString(CultureInfo.InvariantCulture);
            Person2HoursTextBlock.Text = diff.Hours.ToString(CultureInfo.InvariantCulture);
            Person2MinutesTextBlock.Text = diff.Minutes.ToString(CultureInfo.InvariantCulture);
            Person2SecondsTextBlock.Text = diff.Seconds.ToString(CultureInfo.InvariantCulture);

            Person2ElapsedYearsTextBlock.Text = diff.ElapsedYears.ToString(CultureInfo.InvariantCulture);
            Person2ElapsedMonthsTextBlock.Text = diff.ElapsedMonths.ToString(CultureInfo.InvariantCulture);
            Person2ElapsedDaysTextBlock.Text = diff.ElapsedDays.ToString(CultureInfo.InvariantCulture);
            Person2ElapsedHoursTextBlock.Text = diff.ElapsedHours.ToString(CultureInfo.InvariantCulture);
            Person2ElapsedMinutesTextBlock.Text = diff.ElapsedMinutes.ToString(CultureInfo.InvariantCulture);
            Person2ElapsedSecondsTextBlock.Text = diff.ElapsedSeconds.ToString(CultureInfo.InvariantCulture);
        }

        private void UpdatePerson3UI(DateDiff diff)
        {
            Person3YearsTextBlock.Text = diff.Years.ToString(CultureInfo.InvariantCulture);
            Person3MonthsTextBlock.Text = diff.Months.ToString(CultureInfo.InvariantCulture);
            Person3DaysTextBlock.Text = diff.Days.ToString(CultureInfo.InvariantCulture);
            Person3HoursTextBlock.Text = diff.Hours.ToString(CultureInfo.InvariantCulture);
            Person3MinutesTextBlock.Text = diff.Minutes.ToString(CultureInfo.InvariantCulture);
            Person3SecondsTextBlock.Text = diff.Seconds.ToString(CultureInfo.InvariantCulture);

            Person3ElapsedYearsTextBlock.Text = diff.ElapsedYears.ToString(CultureInfo.InvariantCulture);
            Person3ElapsedMonthsTextBlock.Text = diff.ElapsedMonths.ToString(CultureInfo.InvariantCulture);
            Person3ElapsedDaysTextBlock.Text = diff.ElapsedDays.ToString(CultureInfo.InvariantCulture);
            Person3ElapsedHoursTextBlock.Text = diff.ElapsedHours.ToString(CultureInfo.InvariantCulture);
            Person3ElapsedMinutesTextBlock.Text = diff.ElapsedMinutes.ToString(CultureInfo.InvariantCulture);
            Person3ElapsedSecondsTextBlock.Text = diff.ElapsedSeconds.ToString(CultureInfo.InvariantCulture);
        }

        private void SetUIElementVisibility(UIElement control, bool visible)
        {
            if (visible)
            {
                control.Visibility = Visibility.Visible;
            }
            else
            {
                control.Visibility = Visibility.Collapsed;
            }
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Settings.xaml", UriKind.Relative));
        }

        private void MainPagePivot_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}