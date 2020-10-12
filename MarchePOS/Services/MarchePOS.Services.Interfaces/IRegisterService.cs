using System;
using System.Collections.Generic;
using System.Text;

namespace MarchePOS.Services.Interfaces
{
    public interface IRegisterService
    {
        List<PurchasedItem> GetProducts();

        List<PurchasedItem> GetCartProducts();
        void AddProduct(PurchasedItem product);

        void RemoveProduct(PurchasedItem product);
    }
}
