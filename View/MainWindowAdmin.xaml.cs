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
    /// Interaction logic for MainWindowAdmin.xaml
    /// </summary>
    public partial class MainWindowAdmin : Window
    {
        public MainWindowAdmin()
        {
            InitializeComponent();
        }
        private void MainWindowAdminLoaded(object sender, RoutedEventArgs e)
        {
            btnAdminManagement.IsChecked = true;
            contentAdmin.Visibility = Visibility.Visible;

            adminName.Text = LoginWindow.Person.Fullname;

        }

        //Menu
        private void btnAdminManagementChecked(object sender, RoutedEventArgs e)
        {
            contentEmployee.Visibility = Visibility.Collapsed;
            contentCustomer.Visibility = Visibility.Collapsed;
            contentDriver.Visibility = Visibility.Collapsed;
            contentPartner.Visibility = Visibility.Collapsed;


            btnAdminManagement.IsChecked = true;
            contentAdmin.Visibility = Visibility.Visible;
        }

        private void btnEmployeeManagementChecked(object sender, RoutedEventArgs e)
        {
            contentAdmin.Visibility = Visibility.Collapsed;
            contentCustomer.Visibility = Visibility.Collapsed;
            contentDriver.Visibility = Visibility.Collapsed;
            contentPartner.Visibility = Visibility.Collapsed;


            btnEmployeeManagement.IsChecked = true;
            contentEmployee.Visibility = Visibility.Visible;
        }

        private void btnCustomerManagementChecked(object sender, RoutedEventArgs e)
        {
            contentAdmin.Visibility = Visibility.Collapsed;
            contentEmployee.Visibility = Visibility.Collapsed;
            contentDriver.Visibility = Visibility.Collapsed;
            contentPartner.Visibility = Visibility.Collapsed;


            btnCustomerManagement.IsChecked = true;
            contentCustomer.Visibility = Visibility.Visible;
        }

        private void btnDriverManagementChecked(object sender, RoutedEventArgs e)
        {
            contentEmployee.Visibility = Visibility.Collapsed;
            contentCustomer.Visibility = Visibility.Collapsed;
            contentAdmin.Visibility = Visibility.Collapsed;
            contentPartner.Visibility = Visibility.Collapsed;


            btnDriverManagement.IsChecked = true;
            contentDriver.Visibility = Visibility.Visible;
        }

        private void btnPartnerManagementChecked(object sender, RoutedEventArgs e)
        {
            contentEmployee.Visibility = Visibility.Collapsed;
            contentCustomer.Visibility = Visibility.Collapsed;
            contentDriver.Visibility = Visibility.Collapsed;
            contentAdmin.Visibility = Visibility.Collapsed;


            btnPartnerManagement.IsChecked = true;
            contentPartner.Visibility = Visibility.Visible;
        }

        private void logoutButton(object sender, MouseButtonEventArgs e)
        {
            var screen = new StartWindow();
            this.Close();
            screen.Show();
        }
//=======================================Admin Management========================================================
        //Admin List Page navigation
        private void contentaAdminPreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentaAdminNextButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //Options
        private void contentAdminAddButton_Click(object sender, RoutedEventArgs e)
        {
            contentAdminOptionsRemove.Visibility = Visibility.Collapsed;
            contentAdminOptionsUpdate.Visibility = Visibility.Collapsed;

            contentAdminOptionsAdd.Visibility = Visibility.Visible;
        }

        private void contentAdminRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            contentAdminOptionsUpdate.Visibility = Visibility.Collapsed;
            contentAdminOptionsAdd.Visibility = Visibility.Collapsed;

            contentAdminOptionsRemove.Visibility = Visibility.Visible;
        }

        private void contentAdminUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            contentAdminOptionsAdd.Visibility = Visibility.Collapsed;
            contentAdminOptionsRemove.Visibility = Visibility.Collapsed;

            contentAdminOptionsUpdate.Visibility = Visibility.Visible;
        }

        private void contentAdminAddDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentAdminRemoveDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentAdminUpdateDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }


//=======================================Employee Management========================================================
        //Data Grid Page Navigation
        private void contentaEmployeePreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentaEmployeeNextButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //Options
        private void contentEmployeeAddButton_Click(object sender, RoutedEventArgs e)
        {
            contentEmployeeOptionsRemove.Visibility = Visibility.Collapsed;
            contentEmployeeOptionsUpdate.Visibility = Visibility.Collapsed;

            contentEmployeeOptionsAdd.Visibility = Visibility.Visible;
        }

        private void contentEmployeeRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            contentEmployeeOptionsAdd.Visibility = Visibility.Collapsed;
            contentEmployeeOptionsUpdate.Visibility = Visibility.Collapsed;

            contentEmployeeOptionsRemove.Visibility = Visibility.Visible;
        }

        private void contentEmployeeUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            contentEmployeeOptionsRemove.Visibility = Visibility.Collapsed;
            contentEmployeeOptionsAdd.Visibility = Visibility.Collapsed;

            contentEmployeeOptionsUpdate.Visibility = Visibility.Visible;
        }

        private void contentEmployeeAddDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentEmployeeRemoveDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentEmployeeUpdateDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }
//Customer Management=====================================================================================
        private void contentaCustomerPreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentCustomerNextButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void contentCustomerUpdateDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }
//Driver Management=====================================================================================
        private void contentaDriverPreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentDriverNextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentDriverUpdateDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }
//Partner Management=====================================================================================
        private void contentaPartnerPreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentPartnerNextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentPartnerUpdateDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
