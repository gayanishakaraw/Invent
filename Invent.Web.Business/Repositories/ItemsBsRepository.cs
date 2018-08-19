using Invent.Web.Common.Models;
using Invent.Web.DataAccess;

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
    }
}
