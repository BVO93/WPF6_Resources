using System;
using System.Windows.Input;

namespace WiredBrainCoffee.CustomersApp.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;


        public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) // bool>? canExecute = null says that this is an optional parameter. Can be nul. 
        {
            ArgumentNullException.ThrowIfNull(execute);
            _execute = execute;
            _canExecute = canExecute;
        }


        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public event EventHandler? CanExecuteChanged;


        public bool CanExecute(object? parameter)
        {
            return _canExecute is null ? true : _canExecute(parameter);
            // if null return true, else evaluate parameter;
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
