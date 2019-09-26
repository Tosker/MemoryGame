using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace MemoryGame
{
    public class RelayCommand : ICommand
    {
        #region Fields 

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion // Fields 
        #region Constructors 

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        public RelayCommand(RelayCommand myCommand)
        {
        }

        #endregion // Constructors 
        #region ICommand Members 

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            // delegates the event subscription to the CommandManager.RequerySuggested event ensuring that the WPF commanding infrastructure asks all
            // RelayCommand objects if they can execute whenever it asks the built-in commands
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion // ICommand Members 

        /// <summary>
        /// Raises the can execute changed event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            Application.Current.Dispatcher.Invoke(() => CommandManager.InvalidateRequerySuggested());
        }
    }

}