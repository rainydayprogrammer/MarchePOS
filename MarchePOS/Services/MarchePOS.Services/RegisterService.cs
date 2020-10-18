using MarchePOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarchePOS.Services
{
    public class RegisterService : IRegisterService
    {
        readonly string dataDir = @"";

        public List<PurchasedItem> GetTodayPurchasedData()
        {
            throw new NotImplementedException();
        }

        public List<PurchasedItem> GetTodayPurchasedDataByDate(DateTime targetDay)
        {
            throw new NotImplementedException();
        }

        public bool SavePurchasedItems(List<PurchasedItem> purchasedItems)
        {
            if (purchasedItems == null || purchasedItems.Count < 1)
            {
                return false;
            }

            string fileName = dataDir + DateTime.Today.ToString("yyyyMMdd") + ".txt";
            string purchasedDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
            string id = DateTime.Now.ToString("yyyyMMddHHmmss");
            try
            {
                using (var writer = new StreamWriter(fileName, true))
                {
                    foreach(var item in purchasedItems)
                    {
                        writer.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", id, purchasedDate, item.ProducerCode.Trim(), item.ProductCode.Trim(), item.Price.ToString(), item.Quantity.ToString()));
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
