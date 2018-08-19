using Invent.Web.Common.Models;
using Invent.Web.DataAccess;

namespace Invent.Web.Business.Repositories
{
    public class PermissionGroupsBsRepository : GenericRepository<PermissionGroups>, IPermissionGroupsBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public PermissionGroupsBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }
    }
}
