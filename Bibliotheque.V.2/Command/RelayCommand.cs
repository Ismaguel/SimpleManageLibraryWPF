﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bibliotheque.V._2.Command
{
    public class RelayCommand : ICommand
    {
        #region delegate
        Action<object> _execute;
        Predicate<object> _canExecute;
        #endregion
        #region Constructor
        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
