using System;
using System.Windows.Input;

namespace WpfGameOfLife.Presentation.ViewModels
{
    public class DelegateCommand : DelegateCommandBase, ICommand
    {
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
