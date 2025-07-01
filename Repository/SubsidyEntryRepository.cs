
using NetWares.Data;
using NetWares.Interfaces.Repository;
using NetWares.Models;

namespace NetWares.Repository
{
public class SubsidyEntryRepository : GenericRepository<SubsidyEntry>, ISubsidyEntryRepository
{
    public SubsidyEntryRepository(AppDbContext context) : base(context) { }
}
}