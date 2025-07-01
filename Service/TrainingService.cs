

using NetWares.DTOs;
using NetWares.Interfaces;
using NetWares.Interfaces.Repository;
using NetWares.Interfaces.Service;
using NetWares.Mappers;
using NetWares.Models;

namespace NetWares.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _repository;

        public TrainingService(ITrainingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReadTrainingDto>> GetAllAsync()
        {
            var training = await _repository.GetAllAsync();
            if (training.Any()) return [.. training.Select(t => t.ToReadDto())];
            else return [];
        }

        public async Task<ReadTrainingDto?> GetByIdAsync(int id)
        {
            var training = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"data for id {id} not found");
            return training.ToReadDto();
        }

        public async Task AddAsync(CreateTrainingDto createTrainingDto)
        {
            var training = createTrainingDto.ToEntity();
            await _repository.AddAsync(training);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateTrainingDto updateTrainingDto, int id)
        {
            var training = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"data for id {id} not found");
            training.UpdateEntity(updateTrainingDto);
            _repository.Update(training);
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