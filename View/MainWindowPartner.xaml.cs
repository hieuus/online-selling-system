using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MessageBox = System.Windows.Forms.MessageBox;
using Window = System.Windows.Window;

namespace OnlineSellingSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindowPartner.xaml
    /// </summary>
    public partial class MainWindowPartner : Window, INotifyPropertyChanged
    {
        public MainWindowPartner()
        {
            InitializeComponent();

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        //Connect Database
        SqlConnection _connection = null;

        private void ConnectDatabase()
        {
            _connection = new SqlConnection("server=.; database=OnlineSellingDatabase;Trusted_Connection=yes;MultipleActiveResultSets=true");
            _connection.Open();
        }

        //Function
        private int GetBranchIdFromDatabase(int partnerId)
        {
            int branchId = 0;

            string sql =
                $"""
                        SELECT [Branch].BranchId
                	    FROM [Partner] INNER JOIN [Contract] ON [Partner].PartnerId = [Contract].PartnerId
                				   INNER JOIN [Branch] ON [Contract].ContractId = [Branch].ContractId
                        WHERE [Partner].PartnerId = {partnerId}
                """;
            var command = new SqlCommand(sql, _connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                branchId = reader.GetInt32(0);
            }

            _connection.Close();

            return branchId;
        }

        private string GetBranchNameFromDatabase(int partnerId)
        {
            string branchName = string.Empty;

            ConnectDatabase();

            string sql =
                $"""
                        SELECT [Branch].BranchName
                        FROM [Partner] INNER JOIN [Contract] ON [Partner].PartnerId = [Contract].PartnerId
                			   INNER JOIN [Branch] ON [Contract].ContractId = [Branch].ContractId
                        WHERE [Partner].PartnerId = {partnerId}
                """;


            var command = new SqlCommand(sql, _connection);
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                branchName = reader.GetString(0);
            }

            //string sp_getBranchName = "sp_BranchName_Partner";
            //var command = new SqlCommand(sp_getBranchName, _connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.Add(new SqlParameter()
            //{
            //    ParameterName = "@PartnerId",
            //    SqlDbType = System.Data.SqlDbType.Int,
            //    Value = partnerId,
            //});

            //var returnBranchName = command.Parameters.Add("@BranchName", SqlDbType.NChar);
            //returnBranchName.Direction = ParameterDirection.ReturnValue;

            //command.ExecuteNonQuery();

            //var result = returnBranchName.Value;
            //branchName = result.ToString();

            return branchName;
        }

        private int RegisteredTime(int partnerId)
        {
            int registeredTime = 0;

            ConnectDatabase();

            string sql =
                $"""
                    SELECT CONVERT(INT, DATEDIFF(DAY, [Partner].PartnerRegisterTime, GETDATE()))
                    FROM [Partner] INNER JOIN [Contract] ON [Partner].PartnerId = [Contract].PartnerId
                    WHERE [Partner].PartnerId = {partnerId}
                """;
            var command = new SqlCommand(sql, _connection);
            var reader = command.ExecuteReader();
            while( reader.Read())
            {
                registeredTime = reader.GetInt32(0);
            }

            return registeredTime;
        }

        private int GetIntStatus(int partnerId)
        {
            int status = -1;

            ConnectDatabase();

            string sql =
                $"""
                        SELECT [Branch].StatusId
                        FROM [Partner] INNER JOIN [Contract] ON [Partner].PartnerId = [Contract].PartnerId
                			   INNER JOIN [Branch] ON [Contract].ContractId = [Branch].ContractId
                		WHERE [Partner].PartnerId = {partnerId};
                """;

            var command = new SqlCommand(sql, _connection);
            var reader = command.ExecuteReader();

            while(reader.Read())
            {
                status = reader.GetInt32(0);
            }

            return status;
        }

        private string GetOpenTime(int partnerId)
        {
            string openTime = "";

            ConnectDatabase();

            string sql =
                $"""
                        SELECT CONVERT(VARCHAR(8), [Branch].BranchOpenTime, 108)
                        FROM [Partner] INNER JOIN [Contract] ON [Partner].PartnerId = [Contract].PartnerId
                				INNER JOIN [Branch] ON [Contract].ContractId = [Branch].ContractId
                        WHERE [Partner].PartnerId = {partnerId}
                """;
            var command = new SqlCommand(sql, _connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                openTime = reader.GetString(0);
            }

            return openTime;
        }

        private string GetCloseTime(int partnerId)
        {
            string closeTime = "";

            ConnectDatabase();

            string sql =
                $"""
                        SELECT CONVERT(VARCHAR(8), [Branch].BranchCloseTime, 108)
                        FROM [Partner] INNER JOIN [Contract] ON [Partner].PartnerId = [Contract].PartnerId
                				INNER JOIN [Branch] ON [Contract].ContractId = [Branch].ContractId
                        WHERE [Partner].PartnerId = {partnerId}
                """;
            var command = new SqlCommand(sql, _connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                closeTime = reader.GetString(0);
            }

            return closeTime;
        }

        private void UpdateBranchStatus(int branchId, int statusId)
        {
            ConnectDatabase();
            string sp_updateStatus = "sp_UpdateStatus_Branch";
            var command = new SqlCommand(sp_updateStatus, _connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@BranchId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = branchId,
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@StatusId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = statusId,
            });

            command.ExecuteNonQuery();
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

            btnShopManagementChecked(sender, e);


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
            contentShopManagement.Visibility = Visibility.Visible;

            //PartnerId
            int partnerId = LoginWindow.Person.Id;

            //Shop name
            string branchName = GetBranchNameFromDatabase(partnerId);
            shopName.Text = branchName;
            
            //Can Edit Name?
            int registeredTime = RegisteredTime(partnerId);
            if(registeredTime <= 30)
            {
                contentShopNameEdit.Visibility = Visibility.Visible;
            }
            else
            {
                contentShopNameEdit.Visibility = Visibility.Collapsed;
            }

            //Shop status
            int statusId = GetIntStatus(partnerId);
            if (statusId == 6)
                contentShopStatusNormal.IsChecked = true;
            else if(statusId == 3)
                contentShopStatusStop.IsChecked = true;
            else if(statusId == 4)
                contentShopStatusStopOrder.IsChecked = true;

            //Opentime
            string opentTime = GetOpenTime(partnerId);
            placeholderOpenTime.Text = opentTime;

            //CloseTime
            string closeTime = GetCloseTime(partnerId);
            placeholderCloseTime.Text = closeTime;
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
            contentEditShopName.Visibility = Visibility.Visible;
        }

//==================================Content Shop Management Begin====================================
    

        //update shop name
        private void contentShopEditShopNameOkButton(object sender, RoutedEventArgs e)
        {
            int partnerId = LoginWindow.Person.Id;
            string newName = newShopName.Text;

            ConnectDatabase();
            string sp_updateBranchName = "sp_UpdateBranchName_Branch";
            var command = new SqlCommand(sp_updateBranchName, _connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@PartnerId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = partnerId,
            });
            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@BranchName",
                SqlDbType = System.Data.SqlDbType.NChar,
                Value = newName,
            });

            int isSuccess = command.ExecuteNonQuery();
            if(isSuccess == 1)
            {
                MessageBox.Show("Updated Branch Name");
                contentEditShopName.Visibility = Visibility.Collapsed;
                shopName.Text = GetBranchNameFromDatabase(partnerId);
            }
            else
            {
                MessageBox.Show("Can not Edit Branch Name");
                contentEditShopName.Visibility = Visibility.Collapsed;
            }

        }

        //update shop status
        private void contentShopStatusNormalClick(object sender, RoutedEventArgs e)
        {
            int partnerId = LoginWindow.Person.Id;
            int branchId = GetBranchIdFromDatabase(partnerId);
            int statusId = 6;

            UpdateBranchStatus(branchId, statusId);
        }

        //update shop status
        private void contentShopStatusStopOrderClick(object sender, RoutedEventArgs e)
        {
            int partnerId = LoginWindow.Person.Id;
            int branchId = GetBranchIdFromDatabase(partnerId);
            int statusId = 4;

            UpdateBranchStatus(branchId, statusId);
        }

        //update shop status
        private void contentShopStatusStopClick(object sender, RoutedEventArgs e)
        {
            int partnerId = LoginWindow.Person.Id;
            int branchId = GetBranchIdFromDatabase(partnerId);
            int statusId = 3;

            UpdateBranchStatus(branchId, statusId);
        }

        private void updateOpenTime(object sender, RoutedEventArgs e)
        {
            if(openTime.Text == "")
            {
                //Do nothing
            }
            else
            {
                string newOpenTime = openTime.Text;
                int partnerId = LoginWindow.Person.Id;
                int branchId = GetBranchIdFromDatabase(partnerId);

                ConnectDatabase();
                string sp_updateOpenTime = "sp_UpdateBranchOpenTime_Branch";
                var command = new SqlCommand(sp_updateOpenTime, _connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@BranchId",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = branchId,
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@BranchOpenTime",
                    SqlDbType = System.Data.SqlDbType.Time,
                    Value = newOpenTime,
                });

                int isSuccess = command.ExecuteNonQuery();
                if (isSuccess == 1)
                {
                    MessageBox.Show("Updated Open Time");
                    openTime.Text = "";
                    placeholderOpenTime.Text = GetOpenTime(partnerId);
                }
                else
                {
                    MessageBox.Show("Error");
                    openTime.Text = "";
                    placeholderOpenTime.Text = GetOpenTime(partnerId);
                }
            }
        }

        private void updateCloseTime(object sender, RoutedEventArgs e)
        {
            if(closeTime.Text == "")
            {
                //Do nothing
            }
            else
            {
                string newCloseTime = closeTime.Text;
                int partnerId = LoginWindow.Person.Id;
                int branchId = GetBranchIdFromDatabase(partnerId);

                ConnectDatabase();
                string sp_updateCloseTime = "sp_UpdateBranchCloseTime_Branch";
                var command = new SqlCommand(sp_updateCloseTime, _connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@BranchId",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = branchId,
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@BranchCloseTime",
                    SqlDbType = System.Data.SqlDbType.Time,
                    Value = newCloseTime,
                });

                int isSuccess = command.ExecuteNonQuery();
                if (isSuccess == 1)
                {
                    MessageBox.Show("Updated Close Time");
                    closeTime.Text = "";
                    placeholderCloseTime.Text = GetCloseTime(partnerId);
                }
                else
                {
                    MessageBox.Show("Error");
                    closeTime.Text = "";
                    placeholderCloseTime.Text = GetOpenTime(partnerId);
                }
            }
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
        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            contentAddProduct.Visibility = Visibility.Visible;
            contentUpdateProduct.Visibility = Visibility.Collapsed;
            contentRemoveProduct.Visibility = Visibility.Collapsed;
        }

        private void removeProductButton_Click(object sender, RoutedEventArgs e)
        {
            contentAddProduct.Visibility = Visibility.Collapsed;
            contentUpdateProduct.Visibility = Visibility.Collapsed;
            contentRemoveProduct.Visibility = Visibility.Visible;
        }

        private void updateProductButton_Click(object sender, RoutedEventArgs e)
        {
            contentAddProduct.Visibility = Visibility.Collapsed;
            contentUpdateProduct.Visibility = Visibility.Visible;
            contentRemoveProduct.Visibility = Visibility.Collapsed;
        }

        private void addProductDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void removeProductDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void contentProductUpdateDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //================================Content Orders Begin=========================================
        
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
