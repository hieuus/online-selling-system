using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindowPartner.xaml
    /// </summary>
    public partial class MainWindowPartner : Window
    {
        public MainWindowPartner()
        {
            InitializeComponent();

            //Data Content Menu
            var menus = new ObservableCollection<Menu>();
            menus.Add(new Menu { Name = "Bun cha", Description = "Bun cha Ha Noi", Price = "50.000", Status = "Available" });
            menus.Add(new Menu { Name = "Pho", Description = "Pho Ha Noi", Price = "40.000", Status = "Available" });
            menus.Add(new Menu { Name = "Bun bo", Description = "Bun bo Hue", Price = "45.000", Status = "Unavailable" });
            menus.Add(new Menu { Name = "Com tam", Description = "Banh trang Tay Ninh", Price = "30.000", Status = "Unavailable" });
            menus.Add(new Menu { Name = "Chao ca", Description = "Chao ca Hai Lang", Price = "35.000", Status = "Available" });
            menus.Add(new Menu { Name = "Mi quang", Description = "Mi quang Quang Nam", Price = "50.000", Status = "Available" });
            menus.Add(new Menu { Name = "Nem nuong", Description = "Nem nuong Binh Dinh", Price = "25.000", Status = "Available" });

            contentMenuDataGridProduct.ItemsSource = menus;

            //Data Content Orders
            var orders = new ObservableCollection<Order>();
            orders.Add(new Order { id = "001", date = "11/11/2022", customerName = "Nguyen Huu Thang", total = "1.000.000", status = "Dang cho", products = "Bun bo-Bun cha" });
            orders.Add(new Order { id = "002", date = "12/10/2022", customerName = "Tran Nam Thien", total = "900.000", status = "Dang chuan bi", products = "Nem nuong-Tra sua" });
            orders.Add(new Order { id = "003", date = "15/11/2022", customerName = "Tran Duy Quang", total = "780.000", status = "Dang chuan bi", products = "Coffee-Blue sea" });
            orders.Add(new Order { id = "004", date = "14/11/2022", customerName = "Nguyen Van Vu", total = "650.000", status = "Dang cho", products = "Machiato-Americano" });

            contentOrdersListView.ItemsSource = orders;

        }
        //Window Loaded
        private void MainWindowPartnerLoaded(object sender, RoutedEventArgs e)
        {
            contentMenus.Visibility = Visibility.Collapsed;
            contentOrders.Visibility = Visibility.Collapsed;
            contentStatistics.Visibility = Visibility.Collapsed;
            contentWallet.Visibility = Visibility.Collapsed;

            btnShopManagement.IsChecked = true;
            contentShopManagement.Visibility = Visibility.Visible;

            shopOwnerName.Text = LoginWindow.Person.Fullname;


        }
        private void logoutButton(object sender, MouseButtonEventArgs e)
        {
            //log out
            var screen = new StartWindow();
            this.Close();
            screen.Show();
        }
        //Switch Content
        private void btnShopManagementChecked(object sender, RoutedEventArgs e)
        {
            contentMenus.Visibility = Visibility.Collapsed;
            contentOrders.Visibility = Visibility.Collapsed;
            contentStatistics.Visibility = Visibility.Collapsed;
            contentWallet.Visibility = Visibility.Collapsed;

            btnShopManagement.IsChecked = true;
            contentShopManagement.Visibility = Visibility.Visible; ;
        }

        private void btnMenuChecked(object sender, RoutedEventArgs e)
        {
            contentShopManagement.Visibility = Visibility.Collapsed;
            contentOrders.Visibility = Visibility.Collapsed;
            contentStatistics.Visibility = Visibility.Collapsed;
            contentWallet.Visibility = Visibility.Collapsed;

            btnMenu.IsChecked = true;
            contentMenus.Visibility = Visibility.Visible;
        }

        private void btnOrdersChecked(object sender, RoutedEventArgs e)
        {
            contentShopManagement.Visibility = Visibility.Collapsed;
            contentMenus.Visibility = Visibility.Collapsed;
            contentStatistics.Visibility = Visibility.Collapsed;
            contentWallet.Visibility = Visibility.Collapsed;

            btnOrders.IsChecked = true;
            contentOrders.Visibility = Visibility.Visible;
        }

        private void btnStatisticsChecked(object sender, RoutedEventArgs e)
        {
            contentShopManagement.Visibility = Visibility.Collapsed;
            contentMenus.Visibility = Visibility.Collapsed;
            contentOrders.Visibility = Visibility.Collapsed;
            contentWallet.Visibility = Visibility.Collapsed;

            btnStatistics.IsChecked = true;
            contentStatistics.Visibility = Visibility.Visible;
        }

        private void btnWalletChecked(object sender, RoutedEventArgs e)
        {
            contentShopManagement.Visibility = Visibility.Collapsed;
            contentMenus.Visibility = Visibility.Collapsed;
            contentStatistics.Visibility = Visibility.Collapsed;
            contentOrders.Visibility = Visibility.Collapsed;

            btnWallet.IsChecked = true;
            contentWallet.Visibility = Visibility.Visible;
        }

        private void contentShopnameEdit(object sender, MouseButtonEventArgs e)
        {
            //Check date < 30
            //if < 30 contentEditShopName.Visibility = Visibility.Visible;
            //call EditShopNameOkButton
            contentEditShopName.Visibility = Visibility.Visible;
        }

        //==================================Content Shop Management Begin====================================
        private void contentShopEditShopNameOkButton(object sender, RoutedEventArgs e)
        {
            //update shop name
        }

        private void contentShopStatusNormalClick(object sender, RoutedEventArgs e)
        {
            //update shop status
        }

        private void contentShopStatusStopOrderClick(object sender, RoutedEventArgs e)
        {
            //update shop status
        }

        private void contentShopStatusStopClick(object sender, RoutedEventArgs e)
        {
            //update shop status
        }

        private void updateOpenTime(object sender, RoutedEventArgs e)
        {

        }

        private void updateCloseTime(object sender, RoutedEventArgs e)
        {

        }

        private void showRenewContract(object sender, MouseButtonEventArgs e)
        {
            renewContractView.Visibility = Visibility.Visible;
        }


        private void renewContractButton(object sender, RoutedEventArgs e)
        {

        }
        //================================Content Shop Management End================================


        //================================Content Menu Begin=========================================
        public class Menu
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }
            public string Status { get; set; }
        }
        private void contentMenuAddNewProduct(object sender, RoutedEventArgs e)
        {

        }
        private void contentMenuEditButton(object sender, MouseButtonEventArgs e)
        {

        }

        private void contentMenuRemoveButton(object sender, MouseButtonEventArgs e)
        {
                
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //================================Content Menu End=========================================



        //================================Content Orders Begin=========================================
        public class Order
        {
            public string id { get; set; }
            public string date { get; set; }
            public string total { get; set; }
            public string customerName { get; set; }
            public string status { get; set; }
            public string products { get; set; }
        }

        private void contentOrdersEditButton(object sender, MouseButtonEventArgs e)
        {

        }

        private void contentOrdersRemoveButton(object sender, MouseButtonEventArgs e)
        {

        }
        //================================Content Orders End=========================================


        //================================Content Statistics Begin=========================================


        //================================Content Statistics End=========================================


        //================================Content Wallet Begin=========================================
        private void contentWalletOpenWallet_Click(object sender, RoutedEventArgs e)
        {
            contentWalletRegisterWallet.Visibility = Visibility.Visible;
        }

        private void contentWalletConfirmOpenWallet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentWalletTopup_Click(object sender, RoutedEventArgs e)
        {
            contentWalletTopupOpen.Visibility = Visibility.Visible;
        }

        private void contentWalletTopupMoneyOk_Click(object sender, RoutedEventArgs e)
        {

        }
        //================================Content Wallet End=========================================
    }
}
