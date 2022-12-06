using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineSellingSystem.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        //Fields
        private readonly Action<Object> _executetion;
        private readonly Predicate<Object> _canExecuteAction;

        //Constructors
        public ViewModelCommand(Action<object> executetion)
        {
            _executetion = executetion;
            _canExecuteAction = null;
        }
        public ViewModelCommand(Action<object> executetion, Predicate<object> canExecuteAction)
        {
            _executetion = executetion;
            _canExecuteAction = canExecuteAction;
        }

        //Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Methods
        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction != null && _canExecuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
            _executetion?.Invoke(parameter);
        }
    }
}
