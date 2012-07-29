using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.UserData;

namespace HowOld2.WP.Views
{
    public partial class Settings : PhoneApplicationPage
    {
        bool _loaded;
        AppSettings _appSettings = new AppSettings();

        public Settings()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Birthday1RadDatePicker.MaxValue = DateTime.Now;
            Birthday1RadDatePicker.CancelButtonIconUri = new Uri("/Images/appbar.cancel.rest.png", UriKind.Relative);
            Birthday1RadDatePicker.OkButtonIconUri = new Uri("/Images/appbar.check.rest.png", UriKind.Relative);
            Birthday1RadTimePicker.CancelButtonIconUri = new Uri("/Images/appbar.cancel.rest.png", UriKind.Relative);
            Birthday1RadTimePicker.OkButtonIconUri = new Uri("/Images/appbar.check.rest.png", UriKind.Relative);

            Birthday2RadDatePicker.MaxValue = DateTime.Now;
            Birthday2RadDatePicker.CancelButtonIconUri = new Uri("/Images/appbar.cancel.rest.png", UriKind.Relative);
            Birthday2RadDatePicker.OkButtonIconUri = new Uri("/Images/appbar.check.rest.png", UriKind.Relative);
            Birthday2RadTimePicker.CancelButtonIconUri = new Uri("/Images/appbar.cancel.rest.png", UriKind.Relative);
            Birthday2RadTimePicker.OkButtonIconUri = new Uri("/Images/appbar.check.rest.png", UriKind.Relative);

            _loaded = true;
            SetUIElementVisibility(Person2StackPanel, _appSettings.UsePerson2CheckBoxSetting);
            SetUIElementVisibility(Person3StackPanel, _appSettings.UsePerson3CheckBoxSetting);
            SetUIElementVisibility(Birthday1RadTimePicker, _appSettings.UseTime1CheckBoxSetting);
            SetUIElementVisibility(Birthday2RadTimePicker, _appSettings.UseTime2CheckBoxSetting);
            SetUIElementVisibility(Birthday3RadTimePicker, _appSettings.UseTime3CheckBoxSetting);

        }

        private void SetUIElementVisibility(UIElement control, bool visible)
        {
            if (_loaded)
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
        }

        private void UsePerson2CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            SetUIElementVisibility(Person2StackPanel, true);
        }
        private void UsePerson2CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            SetUIElementVisibility(Person2StackPanel, false);

        }

        private void UsePerson3CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            SetUIElementVisibility(Person3StackPanel, true);
        }
        private void UsePerson3CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            SetUIElementVisibility(Person3StackPanel, false);
        }

        private void UseTime1CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            SetUIElementVisibility(Birthday1RadTimePicker, true);
        }
        private void UseTime1CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            SetUIElementVisibility(Birthday1RadTimePicker, false);
        }

        private void UseTime2CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            SetUIElementVisibility(Birthday2RadTimePicker, true);
        }
        private void UseTime2CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            SetUIElementVisibility(Birthday2RadTimePicker, false);
        }

        private void UseTime3CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            SetUIElementVisibility(Birthday3RadTimePicker, true);
        }
        private void UseTime3CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            SetUIElementVisibility(Birthday3RadTimePicker, false);
        }
    }

}