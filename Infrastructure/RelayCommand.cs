using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Infrastructure
{
    class RelayCommand : ICommand
    {
        readonly Predicate<object> predicate;
        readonly Action<object> action;

        public RelayCommand(Action<object> action, Predicate<object> predicate = null)
        {
            this.predicate = predicate;
            this.action = action;
        }


        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }

        }

        public bool CanExecute(object parameter)
        {
            return predicate?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
