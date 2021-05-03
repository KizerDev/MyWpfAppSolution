using System;
using System.Diagnostics;
using System.Windows.Input;

namespace MyWpfAppDemo.Commands
{
    class LaunchExternalLinkCommand : ICommand
    {
        private string _url;

        public LaunchExternalLinkCommand(string urlToOpen)
        {
            _url = urlToOpen;
        }
        public void Execute(object parameter)
        {
            if (string.IsNullOrEmpty(_url)) return;
            Uri uri = new Uri(_url);
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = _url,
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
