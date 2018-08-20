using Invent.Web.Common.Models;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public interface ICompaniesBsRepository : IGenericRepository<Companies>
    {
        Task DeleteAsync(int id);
    }
}
