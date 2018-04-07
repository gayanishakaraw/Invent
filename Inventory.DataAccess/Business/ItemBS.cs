using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business
{
    public class ItemBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static  Item GetItemById(int id)
        {
            return appDb.Items.FirstOrDefault(item => item.ItemId == id);
        }

        public static  List<Item> GetAllItems()
        {
            return appDb.Items.ToList();
        }

        public static  bool IsActiveItem(int id)
        {
            return appDb.Items.FirstOrDefault(item => item.ItemId == id).IsActive;
        }

        public static  Item AddItem(Item customer)
        {
            return appDb.Items.Add(customer);
        }

        public static  void DeleteItem(int id)
        {
            appDb.Items.FirstOrDefault(item => item.ItemId == id).IsActive = false;
            appDb.SaveChanges();
        }
        public static  void EditItem(Item record)
        {
            var itm = appDb.Items.FirstOrDefault(item => item.ItemId == record.ItemId);

            itm.ItemName = record.ItemName;
            itm.CategoryId = record.CategoryId;
            itm.Price = record.Price;
            itm.Remarks = record.Remarks;
            appDb.SaveChanges();
        }
    }
}
