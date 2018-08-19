using Invent.Web.Common.Models;
using Invent.Web.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public class CustomersBsRepository : GenericRepository<Customers>, ICustomersBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public CustomersBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public async Task<bool> IsActiveCustomerAsync(int id)
        {
            return await Task.Run(() => {
                return _dbContext.Customers.FirstOrDefault(item => item.CustomerId == id).IsActive;
            });
        }
    }
}
