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
    /// Interaction logic for MainWindowEmployee.xaml
    /// </summary>
    public partial class MainWindowEmployee : Window
    {
        public MainWindowEmployee()
        {
            InitializeComponent();
        }

        private void MainWindowEmployeeLoaded(object sender, RoutedEventArgs e)
        {
           
            btnPartnerManagement.IsChecked = true;
            contentPartnerManagement.Visibility = Visibility.Visible;
        }

        //===========================================================================
        //Menu Navigation
        private void btnPartnerManagementChecked(object sender, RoutedEventArgs e)
        {
            contentContractManagement.Visibility = Visibility.Collapsed;

            btnPartnerManagement.IsChecked = true;
            contentPartnerManagement.Visibility = Visibility.Visible;
        }

        private void btnContractManagementChecked(object sender, RoutedEventArgs e)
        {
            contentPartnerManagement.Visibility=Visibility.Collapsed;

            btnContractManagement.IsChecked=true;
            contentContractManagement.Visibility=Visibility.Visible;
        }

        private void logoutButton(object sender, MouseButtonEventArgs e)
        {
            //log out
            var screen = new StartWindow();
            this.Close();
            screen.Show();
        }

        private void contentPartnerManagementSeeStatistics_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sendNotiToPartnerExpireContract_Click(object sender, RoutedEventArgs e)
        {

        }
        //Approve Contract
        private void contentContractManagementUnApprovedContractCheckButton(object sender, MouseButtonEventArgs e)
        {

        }
        //Remove Contract
        private void contentContractManagementUnApprovedContractRemvoeButton(object sender, MouseButtonEventArgs e)
        {

        }

       
    }
}
