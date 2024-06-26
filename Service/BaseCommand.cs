﻿using System;
using System.Windows.Input;

namespace TodoWPF.Service
{
    public sealed class BaseCommand : ICommand
    {
        public BaseCommand(
            Action<object> execute,
            Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        private Action<object> execute;

        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }
    }
}
