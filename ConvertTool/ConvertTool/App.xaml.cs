

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Common.RegionAdapter;
using Common.Utility;
using Common.ViewModels;
using Common.Views;
using ConvertTool.Views;
using Games.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Unity;
using SqlData;
using DialogWindow = Common.Views.DialogWindow;

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
            containerRegistry.Register<DbContext>();
            containerRegistry.RegisterDialog<MessageView>();
            containerRegistry.RegisterDialogWindow<DialogWindow>();

            var container = new UnityContainer();

            container.RegisterInstance<IEventAggregator>(new EventAggregator());
            container.RegisterInstance<IContainerProvider>(Container);
            var provider = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => provider);
        }

        protected override Window CreateShell()
        {
            var name = Assembly.GetEntryAssembly()?.GetName().Name??string.Empty;
            if (Process.GetProcessesByName(name).Length > 1)
            {
                // var obj = Process.GetProcessesByName("ConvertTool").FirstOrDefault();
                MessageUtility.ShowMessage("程序已启动");
                return null;
            }
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
