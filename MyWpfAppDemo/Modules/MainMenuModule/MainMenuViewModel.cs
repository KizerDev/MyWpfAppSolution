using AppCore.AppContextData;
using MyWpfAppDemo.Commands;
using MyWpfAppDemo.Shell.Message;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace MyWpfAppDemo.Modules.MainMenuModule
{
    public class MainMenuViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        public IRegionManager RegionManager
        {
            get { return _regionManager; }
            set { _regionManager = value; }
        }

        IContainerExtension _container;
        IModuleManager _moduleManager;

        private string _title = "Clients";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// Le centre se messagerie dans lequel cette classe dépose et/ou récupère ses messages
        /// </summary>
        private IEventAggregator _messagingCenter;
        public IEventAggregator MessagingCenter
        {
            get { return _messagingCenter; }
            set
            {
                _messagingCenter = value;
                //SubscribeToMessagingCenter();
            }
        }

        public MainMenuViewModel(IEventAggregator messagingCenter, IContainerExtension container, IRegionManager regionManager, IModuleManager moduleManager)
        {
            MessagingCenter = messagingCenter;
            RegionManager = regionManager;
            _container = container;
            _moduleManager = moduleManager;
            OpenListeClient = new LaunchExternalLinkCommand(AppContextData.Instance.Site);
            OpenCalculatrice = new LaunchCalculatriceCommand();
            OpenParametrage = new DelegateCommand(OpenParametrageModule);
        }

        private void OpenParametrageModule()
        {
            _moduleManager.LoadModule("ModuleParametrage");
            MessagingCenter.GetEvent<UpdateShellMessage>().Publish();

        }

        public ICommand OpenListeClient { get; set; }
        public ICommand OpenParametrage { get; set; }
        public ICommand OpenCalculatrice { get; set; }
    }
}
