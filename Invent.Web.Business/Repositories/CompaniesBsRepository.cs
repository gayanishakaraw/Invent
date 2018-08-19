using Invent.Web.Common.Models;
using Invent.Web.DataAccess;

namespace Invent.Web.Business.Repositories
{
    public class CompaniesBsRepository : GenericRepository<Companies>, ICompaniesBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public CompaniesBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }
    }
}
