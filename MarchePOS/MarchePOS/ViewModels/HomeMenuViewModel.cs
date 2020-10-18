using MarchePOS.Services.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarchePOS.ViewModels
{
    public class HomeMenuViewModel : BindableBase
    {
        public List<MenuItem> HomeMenuItems { get; set; }

        public HomeMenuViewModel(IMenuService menuService)
        {
            HomeMenuItems = menuService.GetMainMenuItems();
        }
    }
}
