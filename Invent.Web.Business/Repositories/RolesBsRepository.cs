using Invent.Web.Common.Models;
using Invent.Web.DataAccess;

namespace Invent.Web.Business.Repositories
{
    public class RolesBsRepository : GenericRepository<Roles>, IRolesBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public RolesBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }
    }
}
