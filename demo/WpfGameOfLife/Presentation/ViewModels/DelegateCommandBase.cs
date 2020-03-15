using System;

namespace WpfGameOfLife.Presentation.ViewModels
{
    public abstract class DelegateCommandBase
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
    }
}
