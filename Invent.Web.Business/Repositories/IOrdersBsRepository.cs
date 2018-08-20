using Invent.Web.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public interface IOrdersBsRepository : IGenericRepository<Orders>
    {
        Task<bool> IsOrderCompletedAsync(int id);
        Task<List<OrderDetails>> GetActiveItemsInOrderAsync(int id);
        Task<List<OrderDetails>> GetVoidItemsInOrderAsync(int id);
        Task<List<Payments>> GetAllPaymentByOrderIdAsync(int id);

    }
}
