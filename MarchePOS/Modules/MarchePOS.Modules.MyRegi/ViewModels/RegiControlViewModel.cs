using MarchePOS.Core.Mvvm;
using MarchePOS.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace MarchePOS.Modules.MyRegi.ViewModels
{
    public class RegiControlViewModel : RegionViewModelBase
    {
        private string _message;
        private string _title;
        private string _inputData;
        private decimal _totalPrice;
        private int _totalCount;
        private IDialogService _dialogService;
        private IRegisterService _registerService;

        public DelegateCommand DelegateAddToCart { get; private set; }
        public DelegateCommand<PurchasedItem> DelegateRemoveFromCart { get; private set; }

        public DelegateCommand DelegateCheckout { get; private set; }

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        //public string Title
        //{
        //    get { return _title; }
        //    set { SetProperty(ref _title, value); }
        //}

        public string InputData
        {
            get { return _inputData; }
            set { SetProperty(ref _inputData, value); }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { SetProperty(ref _totalPrice, value); }
        }

        public int TotalCount
        {
            get { return _totalCount; }
            set { SetProperty(ref _totalCount, value); }
        }

        public List<PurchasedItem> PurchasedItems { get; private set; }
        public ICollectionView CartLines { get; private set; }

        public RegiControlViewModel(IRegionManager regionManager, IDialogService dialogService, IRegisterService registerService) :
            base(regionManager)
        {
            Message = "レジ打ち用View";

            _dialogService = dialogService;
            _registerService = registerService;

            PurchasedItems = new List<PurchasedItem>();
            CartLines = new ListCollectionView(PurchasedItems);

            DelegateAddToCart = new DelegateCommand(AddToCart);

            DelegateRemoveFromCart = new DelegateCommand<PurchasedItem>(RemoveItem);

            DelegateCheckout = new DelegateCommand(Checkout);
        }

        private void AddToCart()
        {
            if (string.IsNullOrEmpty(InputData))
            {
                Message = "値が正しく取得できませんでした";
                return;
            }
            // 
            string pattern = @"^(?<producerCode>\d{1,4})\-(?<productCode>\d{1,4})\-(?<price>\d{1,6})$";

            Regex r = new Regex(pattern, RegexOptions.None, TimeSpan.FromMilliseconds(150));
            Match m = r.Match(InputData.Trim());
            if (m.Success)
            {
                PurchasedItem item = new PurchasedItem();
                item.Price = decimal.Parse(m.Result("${price}"));
                item.Quantity = 1;
                item.ProducerCode = m.Result("${producerCode}");
                item.ProductCode = m.Result("${productCode}");
                AddPurchasedItem(item);

                InputData = string.Empty;
                Message = string.Empty;
            }
            else
            {
                Message = "値が正しく取得できませんでした";
            }
        }

        private void AddPurchasedItem(PurchasedItem purchasedItem)
        {
            PurchasedItems.Add(purchasedItem);
            CartLines.Refresh();
            UpdateView();
        }

        private void UpdateView()
        {
            int count = 0;
            decimal total = 0;
            foreach (var item in PurchasedItems)
            {
                count += item.Quantity;
                total += item.Price;
            }
            TotalPrice = total;
            TotalCount = count;
        }

        private void Reset()
        {
            PurchasedItems.Clear();
            CartLines.Refresh();
            UpdateView();
        }

        private void RemoveItem(PurchasedItem item)
        {
            PurchasedItems.Remove(item);
            CartLines.Refresh();
            UpdateView();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
            if (PurchasedItems.Count > 0)
            {

            }
        }

        private void Checkout()
        {
            var message = "現在のデータを保存し、画面をクリアします";
            //using the dialog service as-is
            _dialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), r =>
            {
                if (r.Result == ButtonResult.OK) {

                    // データを保存

                    bool saveresult = _registerService.SavePurchasedItems(PurchasedItems);

                    if (saveresult)
                    {
                        Reset();
                        Message = "データを保存しました";
                    }
                    else
                    {
                        Message = "保存に失敗しました！";
                    }
                    // 画面をリセット
                } // OK 以外は何もしない（閉じるだけ）
            });
        }


        //private bool CanExecute()
        //{
        //    return IsEnabled;
        //}
    }
}
