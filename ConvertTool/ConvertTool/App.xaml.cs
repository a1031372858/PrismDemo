

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Common.RegionAdapter;
using Common.ViewModels;
using Common.Views;
using ConvertTool.Views;
using Games.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;
using SqlData;

namespace ConvertTool
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<LoginMainView>();
            containerRegistry.RegisterSingleton<PostgreSqlContext>();
        }

        protected override Window CreateShell()
        {
            var container = new UnityContainer();
            container.RegisterInstance<IEventAggregator>(new EventAggregator());
            container.RegisterInstance<IContainerProvider>(Container);
            var provider = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => provider);
            return Container.Resolve<LoginMainView>();
        }


        protected override IContainerExtension CreateContainerExtension()
        {
            return base.CreateContainerExtension();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var prefix = viewType.FullName.Replace(".Views.", ".ViewModels.").Replace(".UserControls.", ".ViewModels.");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = $"{prefix}Model,{viewAssemblyName}";
                var type = Type.GetType(viewModelName);
                return type;
            });
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            regionAdapterMappings.RegisterMapping<StackPanel>(Container.Resolve<StackPanelRegionAdapter>());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ConvertToolModule>();
        }
    }
}
