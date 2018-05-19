using System;
using System.Windows.Input;

namespace WeatherAppWPF_MVVM.ViewModels.Base
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;


        Action mAction;

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
