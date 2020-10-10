using MarchePOS.Core;
using MarchePOS.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Linq;

namespace MarchePOS.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private bool _mainMenuIsOpen = false;
        private string _title = "マルシェ POS";
        private string _moduleTitle = "Home";
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public List<MenuItem> MainMenuItems { get; set; }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ModuleTitle
        {
            get { return _moduleTitle; }
            set { SetProperty(ref _moduleTitle, value); }
        }

        public bool MainMenuIsOpen
        {
            get { return _mainMenuIsOpen; }
            set { SetProperty(ref _mainMenuIsOpen, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager, IMenuService menuService)
        {
            _regionManager = regionManager;
            MainMenuItems = menuService.GetMainMenuItems();
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigatePath)
        {

            if (navigatePath != null)
                _regionManager.RequestNavigate(RegionNames.ContentRegion, navigatePath, NavigationComplete);

        }

        private void NavigationComplete(NavigationResult result)
        {
            MainMenuIsOpen = false;
            ModuleTitle = MainMenuItems.Where(m => m.NavigatePath == result.Context.Uri.ToString()).FirstOrDefault().Title;
        }
    }
}
