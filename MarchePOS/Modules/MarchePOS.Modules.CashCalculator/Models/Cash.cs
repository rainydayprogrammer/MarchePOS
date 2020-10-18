using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarchePOS.Modules.CashCalculator.Models
{
    public class Cash : INotifyPropertyChanged
    {
        public int Total { get; private set; } = 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged()
        {
            //Total = _one + _five * 5 + _ten * 10 + _fifty * 50 + _hundred * 100 + _fivehundred * 500 + _thousand * 1000 + _fivethousand * 5000 + _tenthousand * 10000;
        }
    }

    public class Money : INotifyPropertyChanged
    {
        public int FaceValue { get; set; } = 0;
        public int Number { get; set; } = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Amount()
        {
            return FaceValue * Number;
        }
    }
}
