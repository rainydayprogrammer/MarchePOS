using System;
using System.Collections.Generic;
using System.Text;

namespace MarchePOS.Services.Interfaces
{
    public interface IRegisterService
    {
        bool SavePurchasedItems(List<PurchasedItem> purchasedItems);

        List<PurchasedItem> GetTodayPurchasedData();

        List<PurchasedItem> GetTodayPurchasedDataByDate(DateTime targetDay);

    }
}
