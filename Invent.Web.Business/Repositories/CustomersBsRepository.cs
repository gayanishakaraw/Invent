using Invent.Web.Common.Models;
using Invent.Web.DataAccess;
using System;
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

        public async Task DeleteAsync(int id)
        {
            var record = (from item in _dbContext.Customers
                          where item.CustomerId == id
                          select item)?.FirstOrDefault();

            if (record == null)
                throw new Exception("Customer is not found!");

            record.IsActive = false;

            _dbContext.Customers.Update(record);
            await _dbContext.SaveChangesAsync();
        }
    }
}
