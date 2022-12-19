using OnlineSellingSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.SqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace OnlineSellingSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindowAdmin.xaml
    /// </summary>
    public partial class MainWindowAdmin : Window, INotifyCollectionChanged
    {
        public MainWindowAdmin()
        {
            InitializeComponent();
        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        ObservableCollection<Person> _subItems = new ObservableCollection<Person>();
        //ObservableCollection<Person> _subItemsAdmin = new ObservableCollection<Person>();
        //ObservableCollection<Person> _subItemsEmployee = new ObservableCollection<Person>();
        //ObservableCollection<Person> _subItemsDriver = new ObservableCollection<Person>();
        //ObservableCollection<Person> _subItemsPartner = new ObservableCollection<Person>();
        //ObservableCollection<Person> _subItemsCustomer = new ObservableCollection<Person>();

        public int RowsPerPage { get; set; } = 20;
        public int TotalPages { get; set; } = 0;
        public int CurrentPage { get; set; } = 1;

        public int TotalItems { get; set; } = 0;

        private int NumberOfPersons(string sqlQueryTotalPerson)
        {
            //Connect Database
            SqlConnection _connection = new SqlConnection("server=HIEUNGUYEN; database=OnlineSellingDatabase;Trusted_Connection=yes");
            _connection.Open();

            //Count number of person: admin/employee/customer/driver/partner
            int adminCount = 0;
            var command = new SqlCommand(sqlQueryTotalPerson, _connection);
            adminCount = (int)command.ExecuteScalar();

            return adminCount;
        }

        private void SelectList20PersonsForAdmin()
        {
            //Connect Database
            SqlConnection _connection = new SqlConnection("server=HIEUNGUYEN; database=OnlineSellingDatabase;Trusted_Connection=yes");
            _connection.Open();

            int offset = (CurrentPage - 1) * RowsPerPage;
            int fetch = RowsPerPage;

            string sqlSelectList20Persons = $"SELECT* FROM Staff WHERE StaffAdmin IS NOT NULL ORDER BY StaffId OFFSET {offset} ROWS FETCH NEXT {fetch} ROWS ONLY";
            var command = new SqlCommand(sqlSelectList20Persons, _connection);
            var reader = command.ExecuteReader();

            _subItems.Clear();
            while(reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("StaffId"));
                string fullName = reader.GetString(reader.GetOrdinal("StaffName"));
                string email = reader.GetString(reader.GetOrdinal("StaffEmail"));
                string phone = reader.GetString(reader.GetOrdinal("StaffPhone"));
                var _person = new Person { Type = "Admin", Id = id, Fullname = fullName, Email = email, PhoneNumber = phone };
                _subItems.Add(_person);
            }

            contentAdminAdminDataGrid.ItemsSource = _subItems;
        }
        private void SelectList20PersonsForEmployee()
        {
            //Connect Database
            SqlConnection _connection = new SqlConnection("server=HIEUNGUYEN; database=OnlineSellingDatabase;Trusted_Connection=yes");
            _connection.Open();

            int offset = (CurrentPage - 1) * RowsPerPage;
            int fetch = RowsPerPage;

            string sqlSelectList20Persons = $"SELECT* FROM Staff WHERE StaffAdmin IS NULL ORDER BY StaffId OFFSET {offset} ROWS FETCH NEXT {RowsPerPage} ROWS ONLY";
            var command = new SqlCommand(sqlSelectList20Persons, _connection);
            var reader = command.ExecuteReader();

            _subItems.Clear();
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("StaffId"));
                string fullName = reader.GetString(reader.GetOrdinal("StaffName"));
                string email = reader.GetString(reader.GetOrdinal("StaffEmail"));
                string phone = reader.GetString(reader.GetOrdinal("StaffPhone"));
                var _person = new Person { Type = "Employee", Id = id, Fullname = fullName, Email = email, PhoneNumber = phone };
                _subItems.Add(_person);
            }

            contentEmployeeDataGrid.ItemsSource = _subItems;
        }
        private void SelectList20Persons(string table)
        {
            //Connect Database
            SqlConnection _connection = new SqlConnection("server=HIEUNGUYEN; database=OnlineSellingDatabase;Trusted_Connection=yes");
            _connection.Open();

            int offset = (CurrentPage - 1) * RowsPerPage;
            int fetch = RowsPerPage;

            string sqlSelectList20Persons = $"SELECT* FROM {table} ORDER BY {table}Id OFFSET {offset} ROWS FETCH NEXT {RowsPerPage} ROWS ONLY";
            var command = new SqlCommand(sqlSelectList20Persons, _connection);
            var reader = command.ExecuteReader();

            _subItems.Clear();
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal($"{table}Id"));
                string fullName = reader.GetString(reader.GetOrdinal($"{table}Name"));
                string email = reader.GetString(reader.GetOrdinal($"{table}Email"));
                string phone = reader.GetString(reader.GetOrdinal($"{table}Phone"));
                var _person = new Person { Type = table, Id = id, Fullname = fullName, Email = email, PhoneNumber = phone };
                _subItems.Add(_person);
            }

            if(table == "Customer")
            {
                contentCustomerDataGrid.ItemsSource = _subItems;
            }
            else if(table == "Driver")
            {
                contentDriverDataGrid.ItemsSource = _subItems;
            }
            else if(table == "Partner")
            {
                contentPartnerDataGrid.ItemsSource = _subItems;
            }
        }

        private void MainWindowAdminLoaded(object sender, RoutedEventArgs e)
        {
            adminName.Text = LoginWindow.Person.Fullname;

            btnAdminManagementChecked(sender, e);
        }
        //Menu
        private void btnAdminManagementChecked(object sender, RoutedEventArgs e)
        {
            //Switch Content
            contentEmployee.Visibility = Visibility.Collapsed;
            contentCustomer.Visibility = Visibility.Collapsed;
            contentDriver.Visibility = Visibility.Collapsed;
            contentPartner.Visibility = Visibility.Collapsed;


            btnAdminManagement.IsChecked = true;
            contentAdmin.Visibility = Visibility.Visible;

            //Data handle
            //Paging
            CurrentPage = 1;

            string sqlQueryTotalAdmin = "SELECT COUNT(*) FROM Staff WHERE StaffAdmin IS NOT NULL";
            TotalItems = NumberOfPersons(sqlQueryTotalAdmin);

            int isDivisible = TotalItems % RowsPerPage;
            if (isDivisible != 0)
            {
                TotalPages = TotalItems / RowsPerPage + 1;
            }
            else
            {
                TotalPages = TotalItems / RowsPerPage;
            }

            adminListCurrentPage.Text = CurrentPage.ToString();
            adminListTotalPage.Text = TotalPages.ToString();

            //Data Grid
            SelectList20PersonsForAdmin();
        }

        private void btnEmployeeManagementChecked(object sender, RoutedEventArgs e)
        {
            contentAdmin.Visibility = Visibility.Collapsed;
            contentCustomer.Visibility = Visibility.Collapsed;
            contentDriver.Visibility = Visibility.Collapsed;
            contentPartner.Visibility = Visibility.Collapsed;


            btnEmployeeManagement.IsChecked = true;
            contentEmployee.Visibility = Visibility.Visible;

            //Data handle
            //Paging
            CurrentPage = 1;

            string sqlQueryTotalAdmin = "SELECT COUNT(*) FROM Staff WHERE StaffAdmin IS NULL";
            TotalItems = NumberOfPersons(sqlQueryTotalAdmin);

            int isDivisible = TotalItems % RowsPerPage;
            if (isDivisible != 0)
            {
                TotalPages = TotalItems / RowsPerPage + 1;
            }
            else
            {
                TotalPages = TotalItems / RowsPerPage;
            }

            employeeListCurrentPage.Text = CurrentPage.ToString();
            employeeListTotalPage.Text = TotalPages.ToString();

            //Data Grid
            SelectList20PersonsForEmployee();
        }

        private void btnCustomerManagementChecked(object sender, RoutedEventArgs e)
        {
            contentAdmin.Visibility = Visibility.Collapsed;
            contentEmployee.Visibility = Visibility.Collapsed;
            contentDriver.Visibility = Visibility.Collapsed;
            contentPartner.Visibility = Visibility.Collapsed;


            btnCustomerManagement.IsChecked = true;
            contentCustomer.Visibility = Visibility.Visible;

            //Data handle
            //Paging
            CurrentPage = 1;

            string sqlQueryTotalAdmin = "SELECT COUNT(*) FROM Customer";
            TotalItems = NumberOfPersons(sqlQueryTotalAdmin);

            int isDivisible = TotalItems % RowsPerPage;
            if (isDivisible != 0)
            {
                TotalPages = TotalItems / RowsPerPage + 1;
            }
            else
            {
                TotalPages = TotalItems / RowsPerPage;
            }

            customerListCurrentPage.Text = CurrentPage.ToString();
            customerListTotalPage.Text = TotalPages.ToString();

            //Data Grid
            SelectList20Persons("Customer");
        }

        private void btnDriverManagementChecked(object sender, RoutedEventArgs e)
        {
            contentEmployee.Visibility = Visibility.Collapsed;
            contentCustomer.Visibility = Visibility.Collapsed;
            contentAdmin.Visibility = Visibility.Collapsed;
            contentPartner.Visibility = Visibility.Collapsed;


            btnDriverManagement.IsChecked = true;
            contentDriver.Visibility = Visibility.Visible;

            //Data handle
            //Paging
            CurrentPage = 1;

            string sqlQueryTotalAdmin = "SELECT COUNT(*) FROM Driver";
            TotalItems = NumberOfPersons(sqlQueryTotalAdmin);

            int isDivisible = TotalItems % RowsPerPage;
            if (isDivisible != 0)
            {
                TotalPages = TotalItems / RowsPerPage + 1;
            }
            else
            {
                TotalPages = TotalItems / RowsPerPage;
            }

            driverListCurrentPage.Text = CurrentPage.ToString();
            driverListTotalPage.Text = TotalPages.ToString();

            //Data Grid
            SelectList20Persons("Driver");
        }

        private void btnPartnerManagementChecked(object sender, RoutedEventArgs e)
        {
            contentEmployee.Visibility = Visibility.Collapsed;
            contentCustomer.Visibility = Visibility.Collapsed;
            contentDriver.Visibility = Visibility.Collapsed;
            contentAdmin.Visibility = Visibility.Collapsed;


            btnPartnerManagement.IsChecked = true;
            contentPartner.Visibility = Visibility.Visible;

            //Data handle
            //Paging
            CurrentPage = 1;

            string sqlQueryTotalAdmin = "SELECT COUNT(*) FROM Partner";
            TotalItems = NumberOfPersons(sqlQueryTotalAdmin);

            int isDivisible = TotalItems % RowsPerPage;
            if (isDivisible != 0)
            {
                TotalPages = TotalItems / RowsPerPage + 1;
            }
            else
            {
                TotalPages = TotalItems / RowsPerPage;
            }

            partnerListCurrentPage.Text = CurrentPage.ToString();
            partnerListTotalPage.Text = TotalPages.ToString();

            //Data Grid
            SelectList20Persons("Partner");
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
            if(CurrentPage <= 1)
            {
                //Do nothing
            }
            else
            {
                _subItems.Clear();
                CurrentPage--;
                adminListCurrentPage.Text = CurrentPage.ToString();
                SelectList20PersonsForAdmin();
            }
        }

        private void contentaAdminNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage == TotalPages)
            {
                //Do nothing
            }
            else
            {
                _subItems.Clear();
                CurrentPage++;
                adminListCurrentPage.Text = CurrentPage.ToString();
                SelectList20PersonsForAdmin();
            }
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
            if (CurrentPage <= 1)
            {
                //Do nothing
            }
            else
            {
                _subItems.Clear();
                CurrentPage--;
                employeeListCurrentPage.Text = CurrentPage.ToString();
                SelectList20PersonsForEmployee();
            }
        }

        private void contentaEmployeeNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage == TotalPages)
            {
                //Do nothing
            }
            else
            {
                _subItems.Clear();
                CurrentPage++;
                employeeListCurrentPage.Text = CurrentPage.ToString();
                SelectList20PersonsForEmployee();
            }
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
            if (CurrentPage <= 1)
            {
                //Do nothing
            }
            else
            {
                _subItems.Clear();
                CurrentPage--;
                customerListCurrentPage.Text = CurrentPage.ToString();
                SelectList20Persons("Customer");
            }
        }

        private void contentCustomerNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage == TotalPages)
            {
                //Do nothing
            }
            else
            {
                _subItems.Clear();
                CurrentPage++;
                customerListCurrentPage.Text = CurrentPage.ToString();
                SelectList20Persons("Customer");
            }
        }
        private void contentCustomerUpdateDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }
//Driver Management=====================================================================================
        private void contentaDriverPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage <= 1)
            {
                //Do nothing
            }
            else
            {
                _subItems.Clear();
                CurrentPage--;
                driverListCurrentPage.Text = CurrentPage.ToString();
                SelectList20Persons("Driver");
            }
        }

        private void contentDriverNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage == TotalPages)
            {
                //Do nothing
            }
            else
            {
                _subItems.Clear();
                CurrentPage++;
                driverListCurrentPage.Text = CurrentPage.ToString();
                SelectList20Persons("Driver");
            }
        }

        private void contentDriverUpdateDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }
//Partner Management=====================================================================================
        private void contentaPartnerPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage <= 1)
            {
                //Do nothing
            }
            else
            {
                _subItems.Clear();
                CurrentPage--;
                partnerListCurrentPage.Text = CurrentPage.ToString();
                SelectList20Persons("Partner");
            }
        }

        private void contentPartnerNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage == TotalPages)
            {
                //Do nothing
            }
            else
            {
                _subItems.Clear();
                CurrentPage++;
                driverListCurrentPage.Text = CurrentPage.ToString();
                SelectList20Persons("Driver");
            }
        }

        private void contentPartnerUpdateDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
