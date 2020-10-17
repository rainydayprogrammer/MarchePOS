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

namespace MarchePOS.Modules.Summary.ViewModels
{
    public class TodaysSummaryViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public TodaysSummaryViewModel(IRegionManager regionManager) : base(regionManager)
        {
            //<materialDesign:PackIcon Kind="BarcodeScan" />
            Message = "本日の売り上げ";
            //menuService.AddMainMenuItem(new MenuItem
            //{
            //    //<materialDesign:PackIcon Kind="FileTableOutline" />
            //    Title = "本日の売上",
            //    Description = "今日の売り上げを集計",
            //    IconName = "FileTableOutline",
            //    NavigatePath = "MarchePOS.Modules.Summary.Views.TodaysSummary"
            //});
        }
    }
}
