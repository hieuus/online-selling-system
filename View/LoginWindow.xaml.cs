using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        string selectedType;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Window_Loaded(object sender, RoutedEventArgs e)
        {
            selectedType = StartWindow.selectedType;

            if(selectedType == "Admin" || selectedType == "Employee")
            {
                moveToSignup.Visibility = Visibility.Collapsed;
            }
        }

        private void btn_back(object sender, MouseButtonEventArgs e)
        {
            var screen = new StartWindow();
            this.Close();
            screen.ShowDialog();
        }

        private void move_to_signup(object sender, MouseButtonEventArgs e)
        {
            if(selectedType == "Customer")
            {
                var screen = new SignupSustomerWindow();
                this.Close();
                screen.ShowDialog();
            }
            else if(selectedType == "Partner")
            {
                var screen = new SignupPartnerWindow();
                this.Close();
                screen.ShowDialog();
            }
            else if(selectedType == "Driver")
            {
                var screen = new SignupDriverWindow();
                this.Close();
                screen.ShowDialog();
            }
        }     
    }
}
