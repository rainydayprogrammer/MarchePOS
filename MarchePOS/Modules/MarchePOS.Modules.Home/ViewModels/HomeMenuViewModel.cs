using MarchePOS.Core.Mvvm;
using MarchePOS.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchePOS.Modules.Home.ViewModels
{
    public class HomeMenuViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public List<MenuItem> HomeMenuItems { get; set; }


        public HomeMenuViewModel(IRegionManager regionManager, IMenuService menuService) :
            base(regionManager)
        {
            Message = "Home Main Menu";

            HomeMenuItems = menuService.GetMainMenuItems();
        }
    }
}
