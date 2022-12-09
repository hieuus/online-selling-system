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
using System.Windows.Shapes;

namespace OnlineSellingSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindowCustomer.xaml
    /// </summary>
    public partial class MainWindowCustomer : Window
    {
        public MainWindowCustomer()
        {
            InitializeComponent();
        }

        private void MainWindowCustomerLoaded(object sender, RoutedEventArgs e)
        {
            btnOrders.IsChecked = true;
            contentOrders.Visibility = Visibility.Visible;
        }

        //Menu Navigation
        private void btnOrdersChecked(object sender, RoutedEventArgs e)
        {
             contentTracking.Visibility = Visibility.Collapsed;

            btnOrders.IsChecked = true;
            contentOrders.Visibility = Visibility.Visible;
        }

        private void btnOrdersTrackingChecked(object sender, RoutedEventArgs e)
        {
            contentOrders.Visibility = Visibility.Collapsed;

            btnOrdersTracking.IsChecked = true;
            contentTracking.Visibility = Visibility.Visible;
        }

        private void logoutButton(object sender, MouseButtonEventArgs e)
        {
            var screen = new StartWindow();
            this.Close();
            screen.Show();
        }


        //Content Orders
        private void contentOrdersProductTopSalesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentOrdersProductPriceLowToHighButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentOrdersProductPriceHighToLowButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentOrdersPartnerButton_Click(object sender, RoutedEventArgs e)
        {
            contentOrdersProductInputPartnerID.Visibility = Visibility.Visible;
        }

        private void contentOrdersProductInputPartnerID_Click(object sender, RoutedEventArgs e)
        {

        }
        //Partner List Paging
        private void contentOrdersPartnerListPreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentOrdersPartnerListNextButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //Product List
        private void contentOrdersProductPreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentOrdersProductNextButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //Select Product
        private void contentOrdersSelectProductSelectButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //Enter Address
        private void contentOrdersPaymentAddress_Click(object sender, RoutedEventArgs e)
        {

        }
        //Order Button
        private void contentOrdersPaymentOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        //Content Tracking=============================================================================
        //Your Orders
        private void contentTrackingYourOrdersPreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentTrackingYourOrdersNextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentTrackingRating_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
