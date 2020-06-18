using System;
using System.Windows.Input;

namespace Group_Project
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> action;
        private Func<object, bool> canExecute;

        public RelayCommand(Action<object> action, Func<object, bool> canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            action.Invoke(parameter);
        }
    }
}
