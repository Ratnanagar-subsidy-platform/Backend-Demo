

using NetWares.Dtos;
using NetWares.Models;

namespace NetWares.Interfaces.Service
{
    public interface ISubsidyService
    {
        Task<IEnumerable<ReadSubsidyDto>> GetAllAsync();
        Task<ReadSubsidyDto> GetByIdAsync(int id);
        Task AddAsync(CreateSubsidyDto createSubsidyDto);
        Task UpdateAsync(UpdateSubsidyDto updateSubsidyDto, int id);
        Task DeleteAsync(int id);
    }
}