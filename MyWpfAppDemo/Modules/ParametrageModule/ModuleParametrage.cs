using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace MyWpfAppDemo.Modules.ParametrageModule
{
    public class ModuleParametrage : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            ViewModelLocationProvider.Register<ParametrageView, ParametrageViewModel>();
            regionManager.RegisterViewWithRegion("PartCenterPanel", typeof(ParametrageView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
