using ConvertTool.UserControls;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ConvertTool
{
    public class ConvertToolModule:IModule
    {
        private IRegionManager _moduleManager;
        public ConvertToolModule(IRegionManager manager)
        {
            _moduleManager = manager;
        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //拿到管理器
            // var regrionManager = containerProvider.Resolve<IRegionManager>();
            //注册模块
            // regrionManager.RegisterViewWithRegion("HeaderRegion", typeof(HeaderView));
            // IRegion region = _moduleManager.Regions["HeaderRegion"];
            // var headerView = containerProvider.Resolve<HeaderView>();
            // region.Add(headerView);
        }
    }
}