using Invent.Web.Common.Models;
using Invent.Web.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public class ItemStocksBsRepository : GenericRepository<ItemStocks>, IItemStocksBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public ItemStocksBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public async Task<bool> IsRequiredToReorderAsync(int id)
        {
            return await Task.Run(() =>
            {
                var stockItem = _dbContext.ItemStocks.FirstOrDefault(item => item.ItemStockId == id);
                return stockItem.Qty <= stockItem.MinimumQty;
            });
        }
    }
}
