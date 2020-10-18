using Prism.Ioc;
using Prism.Regions;
using System.Windows;
using MarchePOS.Core;

namespace MarchePOS.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContainerExtension _container;
        IRegionManager _regionManager;
        IRegion _region;
        HomeMenu _homeMenuView;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _homeMenuView = _container.Resolve<HomeMenu>();
            _region = _regionManager.Regions[RegionNames.ContentRegion];
            _region.Add(_homeMenuView);
            _region.Activate(_homeMenuView);
        }
    }
}
