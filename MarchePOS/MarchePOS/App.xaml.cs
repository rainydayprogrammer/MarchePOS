using Prism.Ioc;
using MarchePOS.Views;
using System.Windows;
using Prism.Modularity;
using MarchePOS.Modules.MyRegi;
using MarchePOS.Services.Interfaces;
using MarchePOS.Services;
using MarchePOS.Core.Dialogs;
using MarchePOS.Modules.Summary;
using MarchePOS.Modules.CashCalculator;

namespace MarchePOS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMenuService, MenuService>();
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<HomeModule>();
            moduleCatalog.AddModule<MyRegiModule>();
            moduleCatalog.AddModule<SummaryModule>();
            moduleCatalog.AddModule<CashCalculatorModule>();

        }
    }
}
