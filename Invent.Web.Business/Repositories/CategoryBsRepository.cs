using System;
using System.Linq;
using System.Threading.Tasks;
using Invent.Web.Common.Models;
using Invent.Web.DataAccess;

namespace Invent.Web.Business.Repositories
{
    public class CategoryBsRepository : GenericRepository<Categories>, ICategoryBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public CategoryBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public async Task DeleteAsync(int id)
        {
            var record = (from item in _dbContext.Categories
                          where item.CategoryId == id
                          select item)?.FirstOrDefault();

            if (record == null)
                throw new Exception("Category is not found!");

            record.IsActive = false;

            _dbContext.Categories.Update(record);
            await _dbContext.SaveChangesAsync();
        }
    }
}
