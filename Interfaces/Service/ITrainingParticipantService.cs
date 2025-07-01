

using NetWares.DTOs;

namespace NetWares.Interfaces.Service
{
    public interface ITrainingParticipantService
    {
        Task<IEnumerable<ReadTrainingParticipantDto>> GetAllAsync();
        Task<ReadTrainingParticipantDto?> GetByIdAsync(int id);
        Task AddAsync(CreateTrainingParticipantDto createTrainingParticipantDto);
        Task UpdateAsync(UpdateTrainingParticipantDto updateTrainingParticipantDto, int id);
        Task DeleteAsync(int id);
    }
}