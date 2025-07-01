using NetWares.Dtos;
using NetWares.Models;

namespace NetWares.Mappers
{
    public static class SubsidyMapper
    {
        public static Subsidy ToEntity(this CreateSubsidyDto dto)
        {
            return new Subsidy
            {
                Title = dto.Title,
                Category = dto.Category,
                Amount = dto.Amount,
                Capacity = dto.Capacity,
                FundSource = dto.FundSource,
                IsDuplicateAllow = dto.IsDuplicateAllow,
                IsInstallment = dto.IsInstallment,
                Remarks = dto.Remarks
            };
        }

        public static void UpdateEntity(this Subsidy entity, UpdateSubsidyDto dto)
        {
            entity.Title = dto.Title;
            entity.Category = dto.Category;
            entity.Amount = dto.Amount;
            entity.Capacity = dto.Capacity;
            entity.FundSource = dto.FundSource;
            entity.IsDuplicateAllow = dto.IsDuplicateAllow;
            entity.IsInstallment = dto.IsInstallment;
            entity.Remarks = dto.Remarks;
        }

        public static ReadSubsidyDto ToReadDto(this Subsidy entity)
        {
            return new ReadSubsidyDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Category = entity.Category,
                Amount = entity.Amount,
                Capacity = entity.Capacity,
                FundSource = entity.FundSource,
                IsDuplicateAllow = entity.IsDuplicateAllow,
                IsInstallment = entity.IsInstallment,
                Remarks = entity.Remarks
            };
        }
    }
}
