using MarchePOS.Core;
using MarchePOS.Modules.MyRegi.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MarchePOS.Modules.MyRegi
{
    public class MyRegiModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public MyRegiModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "RegiControl");

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RegiControl>();
        }

    }
}