﻿using MarchePOS.Core;
using MarchePOS.Modules.MyRegi.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using MarchePOS.Services.Interfaces;

namespace MarchePOS.Modules.MyRegi
{
    public class MyRegiModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IMenuService _menuService;
        public MyRegiModule(IRegionManager regionManager, IMenuService menuService)
        {
            _regionManager = regionManager;
            _menuService = menuService;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "RegiControl");
            _menuService.AddMainMenuItem(new MenuItem
            {
                Title = "レジ打ち",
                Description = "お買い上げ商品の登録",
                IconName = "BarcodeScan",
                NavigatePath = "MarchePOS.Modules.MyRegi.Views.RegiControl"
            });
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RegiControl>();
        }
    }
}