using AppCore.AppContextData;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWpfAppDemo.Modules.ParametrageModule
{
    public class ParametrageViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        public IRegionManager RegionManager
        {
            get { return _regionManager; }
            set { _regionManager = value; }
        }

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

        public string RaisonSociale
        {
            get { return AppContextData.Instance.RaisonSociale; }
            set { AppContextData.Instance.RaisonSociale = value; }
        }

        public ParametrageViewModel(IEventAggregator messagingCenter, IRegionManager regionManager)
        {
            _messagingCenter = messagingCenter;
            _regionManager = regionManager;
        }
    }
}
