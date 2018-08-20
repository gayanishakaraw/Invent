using Invent.Web.Common.Models;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public interface IUsersBsRepository : IGenericRepository<Users>
    {
        Task<Users> AuthenticateAsync(string username, string password);
        Task<Users> CreateAsync(Users user, string password);
        Task DeleteAsync(int id);
    }
}
