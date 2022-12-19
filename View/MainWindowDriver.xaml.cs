using OnlineSellingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OnlineSellingSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindowDriver.xaml
    /// </summary>
    public partial class MainWindowDriver : Window
    {
        public MainWindowDriver()
        {
            InitializeComponent();
        }
        private void MainWindowDriverLoaded(object sender, RoutedEventArgs e)
        {
            btnSelectOrders.IsChecked = true;
            contentSelectOrders.Visibility = Visibility.Visible;

            driverName.Text = LoginWindow.Person.Fullname;
        }

        //Menu
        private void btnSelectChecked(object sender, RoutedEventArgs e)
        {
            contentRevenue.Visibility = Visibility.Collapsed;

            btnSelectOrders.IsChecked = true;
            contentSelectOrders.Visibility = Visibility.Visible;
        }

        private void btnRevenueChecked(object sender, RoutedEventArgs e)
        {
            contentSelectOrders.Visibility=Visibility.Collapsed;

            btnRevenue.IsChecked = true;
            contentRevenue.Visibility = Visibility.Visible;
        }

        //Select Orders
        //Page Navigation
        private void contentSelectOrdersNextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentSelectOrdersPreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void logoutButton(object sender, MouseButtonEventArgs e)
        {
            var screen = new StartWindow();
            this.Close();
            screen.Show();
        }

        private void selectOrder_Click(object sender, RoutedEventArgs e)
        {

        }


        //Revenue
        private void contentRevenuePreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentRevenueNextButton_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
