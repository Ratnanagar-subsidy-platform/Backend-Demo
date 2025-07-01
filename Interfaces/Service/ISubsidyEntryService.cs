
using NetWares.DTOs;
using NetWares.Models;

namespace NetWares.Interfaces.Service
{
    public interface ISubsidyEntryService
    {
        Task<IEnumerable<ReadSubsidyEntryDto>> GetAllAsync();
        Task<ReadSubsidyEntryDto> GetByIdAsync(int id);
        Task AddAsync(CreateSubsidyEntryDto subsidyEntry);
        Task UpdateAsync(UpdateSubsidyEntryDto subsidyEntry, int id);
        Task DeleteAsync(int id);
    }
}