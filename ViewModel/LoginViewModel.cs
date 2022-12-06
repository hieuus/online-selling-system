using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineSellingSystem.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _userName; //email
        private SecureString _password; //phone number
        private string _errorMessage;
        private bool _isViewVisible = true;

        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } }
        public SecureString Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        //Commands
        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }   

        //Constructors
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = true;

            if (string.IsNullOrWhiteSpace(UserName) || Password == null)
            {
                validData = false;
            }
            
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
