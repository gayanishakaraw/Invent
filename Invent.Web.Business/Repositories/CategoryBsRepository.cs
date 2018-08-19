using Invent.Web.Common.Models;
using Invent.Web.DataAccess;

namespace Invent.Web.Business.Repositories
{
    public class CategoryBsRepository : GenericRepository<Categories>, ICategoryBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public CategoryBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }
    }
}
