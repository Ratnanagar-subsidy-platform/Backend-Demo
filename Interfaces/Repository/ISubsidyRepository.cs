
using NetWares.Models;

namespace NetWares.Interfaces.Repository
{
    public interface ISubsidyRepository : IGenericRepository<Subsidy>
    {
        // Add custom methods if needed, e.g.
        Task<Subsidy?> GetByTitleAsync(string title);
    }
}