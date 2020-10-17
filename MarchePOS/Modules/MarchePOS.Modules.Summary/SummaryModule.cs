using MarchePOS.Core;
using MarchePOS.Modules.Summary.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using MarchePOS.Services.Interfaces;

namespace MarchePOS.Modules.Summary
{
    public class SummaryModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IMenuService _menuService;
        public SummaryModule(IRegionManager regionManager, IMenuService menuService)
        {
            _regionManager = regionManager;
            _menuService = menuService;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "TodaysSummary");
            _menuService.AddMainMenuItem(new MenuItem
            {
                Title = "本日の売上",
                Description = "今日の売り上げを集計",
                IconName = "FileTableOutline",
                NavigatePath = "MarchePOS.Modules.Summary.Views.TodaysSummary"
            });
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TodaysSummary>();
        }
    }
}