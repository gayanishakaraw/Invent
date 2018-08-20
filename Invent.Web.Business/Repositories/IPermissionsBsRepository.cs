using Invent.Web.Common;
using Invent.Web.Common.Models;
using System.Threading.Tasks;

namespace Invent.Web.Business.Repositories
{
    public interface IPermissionsBsRepository : IGenericRepository<Permissions>
    {
        Task<bool> CanProceedAsync(int userId, Modules module, Actions eventType);
    }
}
