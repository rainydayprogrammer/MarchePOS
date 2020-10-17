using MarchePOS.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarchePOS.Modules.CashCalculator.ViewModels
{
    public class CalcViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public CalcViewModel(IRegionManager regionManager, IMenuService menuService)
        {
            Message = "現金計算用View";
            menuService.AddMainMenuItem(new MenuItem
            {
                //<materialDesign:PackIcon Kind="FileTableOutline" />
                Title = "現金計算",
                Description = "現金計算用フォーム",
                IconName = "Calculator",
                NavigatePath = "MarchePOS.Modules.Summary.Views.Calc"
            });
        }
    }
}
