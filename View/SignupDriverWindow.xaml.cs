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
    /// Interaction logic for SignupDriverWindow.xaml
    /// </summary>
    public partial class SignupDriverWindow : Window
    {
        public SignupDriverWindow()
        {
            InitializeComponent();
        }
        private void btn_back(object sender, MouseButtonEventArgs e)
        {
            var screen = new LoginWindow();
            this.Close();
            screen.ShowDialog();
        }

        private void move_to_signin(object sender, MouseButtonEventArgs e)
        {
            var screen = new LoginWindow();
            this.Close();
            screen.ShowDialog();
        }
    }
}
