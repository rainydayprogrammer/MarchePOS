using MarchePOS.Core.Mvvm;
using MarchePOS.Services.Interfaces;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarchePOS.Modules.MyRegi.ViewModels
{
    public class RegiControlViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public RegiControlViewModel(IRegionManager regionManager,IMenuService menuService) :
            base(regionManager)
        {
            Message = "レジ打ち用View";
            menuService.AddMainMenuItem(new MenuItem { Title = "レジ打ち", Description = "お買い上げ商品の登録",
                IconName = "Calculator",
                NavigatePath = "MarchePOS.Modules.MyRegi.Views.RegiControl"
            });
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
