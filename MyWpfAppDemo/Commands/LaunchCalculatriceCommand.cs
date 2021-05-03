using System;
using System.Diagnostics;
using System.Windows.Input;

namespace MyWpfAppDemo.Commands
{
    class LaunchCalculatriceCommand : ICommand
    {

        public LaunchCalculatriceCommand()
        {
        }
        public void Execute(object parameter)
        {            
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "calc.exe",
                UseShellExecute = true
            };
            Process.Start(psi);

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
