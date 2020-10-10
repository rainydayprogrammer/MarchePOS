using MarchePOS.Core.Mvvm;
using MarchePOS.Services.Interfaces;
using Prism.Regions;

namespace MarchePOS.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel(IRegionManager regionManager, IMenuService menuService) :
            base(regionManager)
        {
            Message = "テスト用View";
            menuService.AddMainMenuItem(new MenuItem
            {//<materialDesign:PackIcon Kind="FlaskEmpty" />
                //<materialDesign:PackIcon Kind="Grid" />
                //<materialDesign:PackIcon Kind="FileChart" />
                //<materialDesign:PackIcon Kind="ChartLine" />
                //<materialDesign:PackIcon Kind="FileTableOutline" />
                //Cog

                Title = "テスト用",
                Description = "メニュー切り替えテスト用",
                IconName = "FlaskEmpty",
                NavigatePath = "MarchePOS.Modules.ModuleName.Views.ViewA"
            });
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
