using AppCore.AppContextData;
using MyWpfAppDemo.Shell;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpfAppDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IEventAggregator _messageCenter;
        public IEventAggregator MessageCenter
        {
            get { return _messageCenter; }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _messageCenter = new EventAggregator();
            AppContextData.CreateInstance("applicationParam.json");

            ShellBootstrapper bootstrapper = new ShellBootstrapper(MessageCenter);
            bootstrapper.Run();
        }
    }
}
