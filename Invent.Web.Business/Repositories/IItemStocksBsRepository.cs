using Invent.Web.Common.Models;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public interface IItemStocksBsRepository : IGenericRepository<ItemStocks>
    {
        Task<bool> IsRequiredToReorderAsync(int id);
    }
}
