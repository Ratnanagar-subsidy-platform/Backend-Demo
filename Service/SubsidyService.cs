
using NetWares.Dtos;
using NetWares.Interfaces;
using NetWares.Interfaces.Repository;
using NetWares.Interfaces.Service;
using NetWares.Mappers;
using NetWares.Models;

namespace NetWares.Service
{

    public class SubsidyService : ISubsidyService
    {
        private readonly ISubsidyRepository _repository;

        public SubsidyService(ISubsidyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReadSubsidyDto>> GetAllAsync()
        {
            var subsidies = await _repository.GetAllAsync();
            if (subsidies.Any()) return [.. subsidies.Select(s => s.ToReadDto())];
            else return [];
        }

        public async Task<ReadSubsidyDto> GetByIdAsync(int id)
        {
            var subsidy = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"data for id {id} not found");
            return subsidy.ToReadDto();
        }

        public async Task AddAsync(CreateSubsidyDto createSubsidyDto)
        {
            var subsidy = createSubsidyDto.ToEntity();
            await _repository.AddAsync(subsidy);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateSubsidyDto updateSubsidyDto, int id)
        {
            var subsidy = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"data for id {id} not found");
            subsidy.UpdateEntity(updateSubsidyDto);
            _repository.Update(subsidy);
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