using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace StaticPositionSizeCalculator.WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            ApplicationBar = new ApplicationBar();
            ApplicationBar.IsMenuEnabled = true;
            ApplicationBar.IsVisible = true;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.Mode = ApplicationBarMode.Minimized;

            var helpItem = new ApplicationBarIconButton(new Uri("/Images/appbar.questionmark.rest.png", UriKind.Relative));
            var rateItem = new ApplicationBarIconButton(new Uri("/Images/appbar.favs.rest.png", UriKind.Relative));

            helpItem.Text = "help";
            rateItem.Text = "rate";

            helpItem.Click += HelpClick;
            rateItem.Click += RateItemOnClick;

            ApplicationBar.Buttons.Add(helpItem);
            ApplicationBar.Buttons.Add(rateItem);

            adControl1.ApplicationId = "XXXXXX";
            adControl1.AdUnitId = "XXXXXX";
        }
        private void HelpClick(object sender, EventArgs eventArgs)
        {
            NavigationService.Navigate(new Uri("/Help.xaml", UriKind.Relative));
        }
        private void RateItemOnClick(object sender, EventArgs eventArgs)
        {
            MarketplaceReviewTask rate = new MarketplaceReviewTask();
            rate.Show();
        }

        private bool ValidateInput()
        {

            maximumCostTextBox.Foreground = new SolidColorBrush(Colors.Black);
            riskAmountTextBox.Foreground = new SolidColorBrush(Colors.Black);
            buySellPriceTextBox.Foreground = new SolidColorBrush(Colors.Black);

            decimal number;

            // Check that maximumCostTextBox contains valid decimal
            if (Decimal.TryParse(maximumCostTextBox.Text, out number) == false)
            {
                maximumCostTextBox.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Maximum Cost is not valid.", "Error", MessageBoxButton.OK);
                return true;
            }

            // Check that riskAmountTextBox contains valid decimal
            if (Decimal.TryParse(riskAmountTextBox.Text, out number) == false)
            {
                riskAmountTextBox.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Risk Amount is not valid.", "Error", MessageBoxButton.OK);
                return true;
            }

            // Check that buySellPriceTextBox contains valid decimal
            if (Decimal.TryParse(buySellPriceTextBox.Text, out number) == false)
            {
                buySellPriceTextBox.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Buy/Sell Price is not valid.", "Error", MessageBoxButton.OK);
                return true;
            }
            
            // Check that Buy/Sell Price is not larger than Maximum Cost
            if (Decimal.Parse(buySellPriceTextBox.Text) > Decimal.Parse(maximumCostTextBox.Text))
            {
                buySellPriceTextBox.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Buy/Sell Price cannot be larger than Maximum Cost.", "Error", MessageBoxButton.OK);
                return true;
            }
            
            //// Check that if risk type is percent it is not above 100%
            //if ((bool)riskTypePercentRadioButton.IsChecked && (Decimal.Parse(riskAmountTextBox.Text) > 100 || Decimal.Parse(riskAmountTextBox.Text) < 1))
            //{
            //    riskAmountTextBox.Foreground = new SolidColorBrush(Colors.Red);
            //    MessageBox.Show("Risk Percentage must be between 1 and 100.", "Error", MessageBoxButton.OK);
            //    return true;
            //}

            //// Check that if risk type is dollar it is not larger than Maximum Cost
            //if (Decimal.Parse(riskAmountTextBox.Text) > Decimal.Parse(maximumCostTextBox.Text))
            //{
            //    riskAmountTextBox.Foreground = new SolidColorBrush(Colors.Red);
            //    MessageBox.Show("Risk Amount cannot be larger than Maximum Cost.", "Error", MessageBoxButton.OK);
            //    return true;
            //}
            return false;
        }

        private void CalculateButtonClick(object sender, RoutedEventArgs e)
        {
            if(ValidateInput() == false)
            {
                StaticPositionSize.PositionType position;
                if((bool)riskLongRadioButton.IsChecked)
                {
                    position = StaticPositionSize.PositionType.Long;
                }
                else
                {
                    position = StaticPositionSize.PositionType.Short;
                }
                StaticPositionSize data = new StaticPositionSize(
                    Decimal.Parse(maximumCostTextBox.Text), 
                    riskTypePercentRadioButton.IsChecked != null && (bool) riskTypePercentRadioButton.IsChecked, 
                    Decimal.Parse(riskAmountTextBox.Text),
                    Decimal.Parse(buySellPriceTextBox.Text),
                    position);
                sharesToBuySellTextBox.Text = data.CalculateSharesToBuySell().ToString(CultureInfo.InvariantCulture);
                stopPriceTextBox.Text = data.CalculateStopPrice().ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}