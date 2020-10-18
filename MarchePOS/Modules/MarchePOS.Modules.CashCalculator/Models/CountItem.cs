using MarchePOS.Core.Mvvm;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarchePOS.Modules.CashCalculator.Models
{
    public class CountItem : DomainObject
    {
        /// <summary>
        /// お金の種類（1000円とか10円とか）
        /// </summary>
        private string _moneyType;
        public string MoneyType
        {
            get { return _moneyType; }
            set
            {
                SetProperty(ref _moneyType, value);
            }
        }

        /// <summary>
        /// 種類ごとの金額
        /// </summary>
        private decimal _mondeyValue;
        public decimal MondeyValue
        {
            get { return _mondeyValue; }
            set
            {
                SetProperty(ref _mondeyValue, value);
            }
        }

        /// <summary>
        /// 個数、枚数
        /// </summary>
        private int _moneyCount = 0;
        [Range(0, 99999, ErrorMessage = "マイナスはダメです")]
        public int MoneyCount
        {
            get { return _moneyCount; }
            set
            {
                SetProperty(ref _moneyCount, value);
                RaisePropertyChanged(nameof(AmountByType)); // この方がまだまし？
            }
        }

        /// <summary>
        /// 種類ごとの金額を返す
        /// </summary>
        /// <returns>種類毎の金額</returns>
        public decimal AmountByType
        {
            get { return MondeyValue * MoneyCount; }
        }
    }
}
