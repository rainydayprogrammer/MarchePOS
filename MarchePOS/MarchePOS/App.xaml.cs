using Prism.Ioc;
using MarchePOS.Views;
using System.Windows;
using Prism.Modularity;
using MarchePOS.Modules.MyRegi;
using MarchePOS.Modules.ModuleName;
using MarchePOS.Services.Interfaces;
using MarchePOS.Services;

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
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MyRegiModule>();
            //moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
