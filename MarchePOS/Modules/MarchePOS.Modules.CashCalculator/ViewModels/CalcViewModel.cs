using MarchePOS.Core.Mvvm;
using MarchePOS.Modules.CashCalculator.Models;
using MarchePOS.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MarchePOS.Modules.CashCalculator.ViewModels
{
    public class CalcViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public ICollectionView CountItems { get; private set; }

        public decimal GrandTotal
        {
            get { return CountItems.OfType<CountItem>().Sum(m => m.AmountByType); }
        }

        public CalcViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Message = "現金計算用View";
            CountItems = new ListCollectionView(new ObservableCollection<CountItem> {
                new CountItem{MoneyType = "1円", MondeyValue = 1, MoneyCount = 0 },
                new CountItem{MoneyType= "5円", MondeyValue = 5, MoneyCount = 0},
                new CountItem{MoneyType= "10円", MondeyValue = 10, MoneyCount = 0},
                new CountItem{MoneyType= "50円", MondeyValue = 50, MoneyCount = 0},
                new CountItem{MoneyType= "100円", MondeyValue = 100, MoneyCount = 0},
                new CountItem{MoneyType= "500円", MondeyValue = 500, MoneyCount = 0},
                new CountItem{MoneyType= "1,000円", MondeyValue = 1000, MoneyCount = 0},
                new CountItem{MoneyType= "5,000円", MondeyValue = 5000, MoneyCount = 0},
                new CountItem{MoneyType= "10,000円", MondeyValue = 10000, MoneyCount = 0}
            });

            CountItems.CurrentChanged += SelectedItemChanged;
        }

        private void SelectedItemChanged(object sender, EventArgs e)
        {
            RaisePropertyChanged(nameof(GrandTotal));
        }
    }
}
