using System;
using System.Collections.Generic;
using System.Text;

namespace MarchePOS.Services.Interfaces
{
    public class PurchasedInfo : PurchasedItem
    {
        public string Id { get; set; }
        public DateTime PurchasedDate { get; set; }

        public PurchasedInfo()
        {

        }
    }
}
