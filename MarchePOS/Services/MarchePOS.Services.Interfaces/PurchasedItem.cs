using System;
using System.Collections.Generic;
using System.Text;

namespace MarchePOS.Services.Interfaces
{
    public class PurchasedItem
    {   
        public string ProducerCode { get; set; }

        public string ProductCode { get; set; }

        public Decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
