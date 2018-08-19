using Invent.Web.Common.Models;
using Invent.Web.DataAccess;

namespace Invent.Web.Business.Repositories
{
    public class PaymentsBsRepository : GenericRepository<Payments>, IPaymentsBsRepository
    {
        private readonly InventoryDbContext _dbContext;
        public PaymentsBsRepository(InventoryDbContext context)
            : base(context)
        {
            _dbContext = context;
        }
    }
}
