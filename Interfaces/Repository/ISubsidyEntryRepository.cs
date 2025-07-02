
using NetWares.Models;

namespace NetWares.Interfaces.Repository
{
    public interface ISubsidyEntryRepository : IGenericRepository<SubsidyEntry>
    {
        Task<SubsidyEntry?> GetByCitizenship(string citizenship);
    }
}