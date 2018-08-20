using Invent.Web.Common.Models;
using Invent.Web.DataAccess;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Invent.Web.Business.Repositories
{
    public class ItemsBsRepository : GenericRepository<Items>, IItemsBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public ItemsBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public async Task DeleteAsync(int id)
        {
            var record = (from item in _dbContext.Items
                          where item.ItemId == id
                          select item)?.FirstOrDefault();

            if (record == null)
                throw new Exception("Item is not found");

            record.IsActive = false;

            _dbContext.Items.Update(record);
            await _dbContext.SaveChangesAsync();
        }
    }
}
