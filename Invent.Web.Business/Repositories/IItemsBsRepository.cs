using Invent.Web.Common.Models;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public interface IItemsBsRepository : IGenericRepository<Items>
    {
        Task DeleteAsync(int id);
    }
}
