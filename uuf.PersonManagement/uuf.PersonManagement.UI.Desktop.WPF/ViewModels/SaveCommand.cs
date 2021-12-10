using System;
using System.Windows.Input;

namespace uuf.PersonManagement.UI.Desktop.WPF.ViewModels
{
    internal class SaveCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return false;
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}