using Invent.Web.Common.Models;
using Invent.Web.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task DeleteAsync(int id)
        {
            var record = (from item in _dbContext.Companies
                        where item.CompanyId == id
                        select item)?.FirstOrDefault();

            if (record == null)
                throw new Exception("Company not found");

            record.IsActive = false;

            _dbContext.Companies.Update(record);
            await _dbContext.SaveChangesAsync();
        }
    }
}
