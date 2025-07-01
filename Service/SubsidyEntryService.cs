using NetWares.DTOs;
using NetWares.Interfaces;
using NetWares.Interfaces.Repository;
using NetWares.Interfaces.Service;
using NetWares.Mappers;

namespace NetWares.Service;
public class SubsidyEntryService : ISubsidyEntryService

{
    private readonly ISubsidyEntryRepository _repository;

    public SubsidyEntryService(ISubsidyEntryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ReadSubsidyEntryDto>> GetAllAsync()
    {
        var subsidyEntry = await _repository.GetAllAsync();
        if (subsidyEntry.Any()) return [.. subsidyEntry.Select(e => e.ToReadDto())];
        else return [];
    }

    public async Task<ReadSubsidyEntryDto> GetByIdAsync(int id) {
        var subsidyEntry = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"data for id {id} not found");
        return subsidyEntry.ToReadDto();
    }

    public async Task AddAsync(CreateSubsidyEntryDto createSubsidyEntryDto)
    {
        var subsidyEntry = createSubsidyEntryDto.ToEntity();
        await _repository.AddAsync(subsidyEntry);
        await _repository.SaveChangesAsync();
    }

    public async Task UpdateAsync(UpdateSubsidyEntryDto updateSubsidyEntryDto, int id)
    {
        var subsidyEntry = await _repository.GetByIdAsync(id)?? throw new KeyNotFoundException($"data for id {id} not found");
        subsidyEntry.UpdateEntity(updateSubsidyEntryDto);
        _repository.Update(subsidyEntry);
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