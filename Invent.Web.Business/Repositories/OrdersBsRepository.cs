using Invent.Web.Common.Models;
using Invent.Web.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public class OrdersBsRepository : GenericRepository<Orders>, IOrdersBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public OrdersBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public async Task<bool> IsOrderCompletedAsync(int id)
        {
            return await Task.Run(() =>
            {
                var order = (from item in _dbContext.Orders
                             where item.OrderId == id
                             select item).FirstOrDefault();

                var payments = from item in _dbContext.Payments
                               where item.OrderId == id
                               select item;

                var totalPaid = payments.AsEnumerable().Sum(o => o.Amount);

                return totalPaid == order.TotalAmount;
            });
        }

        public async Task<List<OrderDetails>> GetActiveItemsInOrderAsync(int id)
        {
            var query = from item in _dbContext.OrderDetails
                        where item.OrderId == id && !item.IsVoid
                        select item;

            return await query.ToListAsync();
        }

        public async Task<List<OrderDetails>> GetVoidItemsInOrderAsync(int id)
        {
            var query = from item in _dbContext.OrderDetails
                        where item.OrderId == id && item.IsVoid
                        select item;

            return await query.ToListAsync();
        }

        public async Task<List<Payments>> GetAllPaymentByOrderIdAsync(int id)
        {
            var query = from item in _dbContext.Payments
                        where item.OrderId == id
                        select item;

            return await query.ToListAsync();
        }
    }
}
