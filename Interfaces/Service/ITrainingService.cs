
using NetWares.DTOs;

namespace NetWares.Interfaces.Service
{
    public interface ITrainingService
    {
        Task<IEnumerable<ReadTrainingDto>> GetAllAsync();
        Task<ReadTrainingDto?> GetByIdAsync(int id);
        Task AddAsync(CreateTrainingDto createTrainingDto);
        Task UpdateAsync(UpdateTrainingDto updateTrainingDto, int id);
        Task DeleteAsync(int id);
    }
}