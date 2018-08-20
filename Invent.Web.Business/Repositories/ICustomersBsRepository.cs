using Invent.Web.Common.Models;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public interface ICustomersBsRepository : IGenericRepository<Customers>
    {
        Task DeleteAsync(int id);

        Task<bool> IsActiveCustomerAsync(int id);
    }
}
