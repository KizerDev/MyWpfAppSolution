using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace MyWpfAppDemo.Modules.MainMenuModule
{
    [Module(ModuleName = "ModuleMenuPrincipal")]
    public class ModuleMainMenu : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            ViewModelLocationProvider.Register<MainMenuView, MainMenuViewModel>();
            regionManager.RegisterViewWithRegion("PartLeftMenu", typeof(MainMenuView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<MainMenuViewModel>();
        }
    }
}
