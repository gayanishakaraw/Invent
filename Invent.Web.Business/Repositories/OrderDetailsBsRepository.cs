using Invent.Web.Common.Models;
using Invent.Web.DataAccess;

namespace Invent.Web.Business.Repositories
{
    public class OrderDetailsBsRepository : GenericRepository<OrderDetails>, IOrderDetailsBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public OrderDetailsBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }
    }
}
