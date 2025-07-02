
using Microsoft.EntityFrameworkCore;
using NetWares.Data;
using NetWares.Interfaces.Repository;
using NetWares.Models;

namespace NetWares.Repository
{
    public class SubsidyEntryRepository : GenericRepository<SubsidyEntry>, ISubsidyEntryRepository
    {
        public SubsidyEntryRepository(AppDbContext context) : base(context) {
         }

        public async Task<SubsidyEntry?> GetByCitizenship(string citizenship)
        {
            var data = await _dbSet.FirstOrDefaultAsync(d => d.CitizenshipNumber == citizenship);
            return data;
        }
}
}