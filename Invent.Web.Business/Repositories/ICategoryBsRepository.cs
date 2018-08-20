using Invent.Web.Common.Models;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public interface ICategoryBsRepository : IGenericRepository<Categories>
    {
        Task DeleteAsync(int id);
    }
}
