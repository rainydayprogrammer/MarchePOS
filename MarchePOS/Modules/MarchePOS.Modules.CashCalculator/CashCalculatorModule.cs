using MarchePOS.Core;
using MarchePOS.Modules.CashCalculator.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MarchePOS.Modules.CashCalculator
{
    public class CashCalculatorModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public CashCalculatorModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;

        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "Calc");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Calc>();
        }
    }
}