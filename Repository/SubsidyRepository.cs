using Microsoft.EntityFrameworkCore;
using NetWares.Data;
using NetWares.Interfaces.Repository;
using NetWares.Models;

namespace NetWares.Repository
{
    public class SubsidyRepository : GenericRepository<Subsidy>, ISubsidyRepository
    {
        public SubsidyRepository(AppDbContext context) : base(context) { }

        public async Task<Subsidy?> GetByTitleAsync(string title)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase));
        }
}
}