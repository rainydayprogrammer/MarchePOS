using MarchePOS.Core;
using MarchePOS.Modules.Home.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using MarchePOS.Services.Interfaces;

namespace MarchePOS.Modules.Home
{
    public class HomeModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IMenuService _menuService;

        public HomeModule(IRegionManager regionManager, IMenuService menuService)
        {
            _regionManager = regionManager;
            _menuService = menuService;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "HomeMenu");

            _menuService.AddMainMenuItem(new MenuItem
            {
                Title = "ホーム",
                Description = "メインメニュー",
                IconName = "Home",
                NavigatePath = "MarchePOS.Modules.Home.Views.HomeMenu"
            });
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeMenu>();
        }
    }
}