using Inventory.DataAccess;
using Inventory.DataAccess.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business.Inventory
{
    public class ItemStockBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static ItemStock GetItemStockById(int id)
        {
            return appDb.ItemStocks.FirstOrDefault(item => item.ItemStockId == id);
        }

        public static List<ItemStock> GetAllItemStocks()
        {
            return appDb.ItemStocks.ToList();
        }

        public static bool IsRequiredToReorder(int id)
        {
            var stockItem = appDb.ItemStocks.FirstOrDefault(item => item.ItemStockId == id);

            return stockItem.Qty <= stockItem.MinimumQty;
        }

        public static ItemStock AddItemStock(ItemStock itemStock)
        {
            if (GetItemStockById(itemStock.ItemStockId) != null)
            {
                EditItemStock(itemStock);
                return itemStock;
            }
            else
            {
                var record = appDb.ItemStocks.Add(itemStock);
                appDb.SaveChanges();
                return record;
            }
        }

        public static void DeleteItemStock(int id)
        {
            appDb.ItemStocks.FirstOrDefault(item => item.ItemStockId == id).Qty = 0;
            appDb.SaveChanges();
        }
        public static void EditItemStock(ItemStock record)
        {
            var itm = appDb.ItemStocks.FirstOrDefault(item => item.ItemStockId == record.ItemStockId);

            itm.MinimumQty = record.MinimumQty;
            itm.Qty = record.Qty;
            itm.Remarks = record.Remarks;
            appDb.SaveChanges();
        }

        public static void UpdateStock(int itemId, decimal qty)
        {
            var itm = appDb.ItemStocks.FirstOrDefault(item => item.ItemId == itemId);
            itm.Qty = itm.Qty + qty;
            appDb.SaveChanges();
        }
    }
}
