using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ColorSelectorSamuelBering.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _action;
        private Predicate<object> _canExecute;

        public DelegateCommand(Action<object> execute) : this(execute, null) { }
        public DelegateCommand(Action<object> action, Predicate<object> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //#pragma warning disable 67
        //        public event EventHandler CanExecuteChanged;
        //#pragma warning restore 67
    }
}
