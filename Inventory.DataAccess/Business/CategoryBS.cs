using Inventory.DataAccess;
using Inventory.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.DataAccess.Business
{
    public class CategoryBS
    {
        static AppDbContext appDb = new AppDbContext();

        public static Category GetCategoryById(int id)
        {
            return appDb.Categories.FirstOrDefault(item => item.CategoryId == id);
        }

        public static List<Category> GetAllCategories()
        {
            return appDb.Categories.ToList();
        }

        public static bool IsActiveCategory(int id)
        {
            return appDb.Categories.FirstOrDefault(item => item.CategoryId == id).IsActive;
        }

        public static Category AddCategory(Category category)
        {
            return appDb.Categories.Add(category);
        }

        public static void DeleteCategory(int id)
        {
            appDb.Categories.FirstOrDefault(item => item.CategoryId == id).IsActive = false;
            appDb.SaveChanges();
        }
        public static void EditCategory(Category record)
        {
            var itm = appDb.Categories.FirstOrDefault(item => item.CategoryId == record.CategoryId);

            itm.CategoryName = record.CategoryName;
            itm.IsActive = record.IsActive;
            itm.UnitOfMeasure = record.UnitOfMeasure;
            itm.Remarks = record.Remarks;
            appDb.SaveChanges();
        }
    }
}
