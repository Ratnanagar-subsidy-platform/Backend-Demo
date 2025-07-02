using System.Data;
using NetWares.DTOs;
using NetWares.Interfaces.Repository;
using NetWares.Interfaces.Service;
using NetWares.Mappers;

namespace NetWares.Service
{
    public class TrainingParticipantService : ITrainingParticipantService
    {
        private readonly ITrainingParticipantRepository _repository;

        public TrainingParticipantService(ITrainingParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReadTrainingParticipantDto>> GetAllAsync()
        {
            var trainingParticipants = await _repository.GetAllAsync();
            if (trainingParticipants.Any()) return [.. trainingParticipants.Select(t => t.ToReadDto())];
            else return [];
        }

        public async Task<ReadTrainingParticipantDto?> GetByIdAsync(int id)
        {
            var trainingParticipant = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"data for id {id} not found");
            return trainingParticipant.ToReadDto();
        }

        public async Task AddAsync(CreateTrainingParticipantDto createTrainingParticipantDto)
        {
            var existingData = await _repository.GetByCitizenship(createTrainingParticipantDto.CitizenshipNumber);
            if (existingData is not null) throw new DuplicateNameException("Data for provided citizenship already exists");
            var trainingParticipant = createTrainingParticipantDto.ToEntity();
            await _repository.AddAsync(trainingParticipant);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateTrainingParticipantDto updateTrainingParticipantDto, int id)
        {
            var trainingParticipant = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"data for id {id} not found");
            trainingParticipant.UpdateEntity(updateTrainingParticipantDto);
            _repository.Update(trainingParticipant);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                _repository.Delete(entity);
                await _repository.SaveChangesAsync();
            }
        }
    }
}