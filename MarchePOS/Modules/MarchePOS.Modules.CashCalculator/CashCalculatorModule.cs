using MarchePOS.Core;
using MarchePOS.Modules.CashCalculator.Views;
using MarchePOS.Services.Interfaces;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MarchePOS.Modules.CashCalculator
{
    public class CashCalculatorModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IMenuService _menuService;

        public CashCalculatorModule(IRegionManager regionManager, IMenuService menuService)
        {
            _regionManager = regionManager;
            _menuService = menuService;

        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "Calc");
            _menuService.AddMainMenuItem(new MenuItem
            {
                Title = "現金計算",
                Description = "現金計算用フォーム",
                IconName = "Calculator",
                NavigatePath = "MarchePOS.Modules.CashCalculator.Views.Calc"
            });
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Calc>();
        }
    }
}