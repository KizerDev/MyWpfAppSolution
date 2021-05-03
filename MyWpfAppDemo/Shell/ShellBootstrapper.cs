using MyWpfAppDemo.Modules.MainMenuModule;
using MyWpfAppDemo.Modules.ParametrageModule;
using MyWpfAppDemo.Shell.Message;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Windows;

namespace MyWpfAppDemo.Shell
{
    class ShellBootstrapper : PrismBootstrapper
    {
        public IEventAggregator EventAggregator;

        public ShellBootstrapper(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            SubscribeToEventAggregator();
        }

        private void SubscribeToEventAggregator()
        {
            EventAggregator.GetEvent<UpdateShellMessage>().Subscribe(UpdateShell);
        }

        private void UpdateShell()
        {
            
        }

        protected override DependencyObject CreateShell()
        {
            var view = Container.Resolve<ShellWindow>();
            return view;
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<ModuleMainMenu>();
            Type moduleCType = typeof(ModuleParametrage);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType.Name,
                ModuleType = moduleCType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(EventAggregator);
            containerRegistry.Register<ShellViewModel>();
            containerRegistry.Register<ShellWindow>();
            containerRegistry.Register<ModuleParametrage>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<ShellWindow, ShellViewModel>();
        }        
    }
}
