using NetWares.DTOs;
using NetWares.Models;

namespace NetWares.Mappers
{
    public static class SubsidyEntryMapper
    {
        public static SubsidyEntry ToEntity(this CreateSubsidyEntryDto dto)
        {
            var entity = new SubsidyEntry
            {
                SubsidyTitle = dto.SubsidyTitle,
                SubsidyId = dto.SubsidyId,
                FullName = dto.FullName,
                CitizenshipNumber = dto.CitizenshipNumber,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                TemporaryAddress = dto.TemporaryAddress,
                PermanentAddress = dto.PermanentAddress,
                Municipality = dto.Municipality,
                Ward = dto.Ward,
                Tole = dto.Tole,
                Occupation = dto.Occupation,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                SubsidyDemandLetterFilePath = dto.SubsidyDemandLetterFilePath,
                PaperDocumentFilePath = dto.PaperDocumentFilePath,
                NeededAmount = dto.NeededAmount,
                GotAmount = dto.GotAmount,
                FundSettlementStatus = dto.FundSettlementStatus,
                BankName = dto.BankName,
                AccountName = dto.AccountName,
                AccountNumber = dto.AccountNumber,
                BankBranch = dto.BankBranch
            };

            entity.CalculateAge();
            return entity;
        }

        public static void UpdateEntity(this SubsidyEntry entity, UpdateSubsidyEntryDto dto)
        {
            entity.SubsidyTitle = dto.SubsidyTitle;
            entity.FullName = dto.FullName;
            entity.CitizenshipNumber = dto.CitizenshipNumber;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.Email = dto.Email;
            entity.TemporaryAddress = dto.TemporaryAddress;
            entity.PermanentAddress = dto.PermanentAddress;
            entity.Municipality = dto.Municipality;
            entity.Ward = dto.Ward;
            entity.Tole = dto.Tole;
            entity.SubsidyId = dto.SubsidyId;
            entity.Occupation = dto.Occupation;
            entity.DateOfBirth = dto.DateOfBirth;
            entity.Gender = dto.Gender;
            entity.SubsidyDemandLetterFilePath = dto.SubsidyDemandLetterFilePath;
            entity.PaperDocumentFilePath = dto.PaperDocumentFilePath;
            entity.NeededAmount = dto.NeededAmount;
            entity.GotAmount = dto.GotAmount;
            entity.FundSettlementStatus = dto.FundSettlementStatus;
            entity.BankName = dto.BankName;
            entity.AccountName = dto.AccountName;
            entity.AccountNumber = dto.AccountNumber;
            entity.BankBranch = dto.BankBranch;

            entity.CalculateAge();
        }

        public static ReadSubsidyEntryDto ToReadDto(this SubsidyEntry entity)
        {
            return new ReadSubsidyEntryDto
            {
                Id = entity.Id,
                SubsidyTitle = entity.SubsidyTitle,
                SubsidyId = entity.SubsidyId,
                FullName = entity.FullName,
                CitizenshipNumber = entity.CitizenshipNumber,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                TemporaryAddress = entity.TemporaryAddress,
                PermanentAddress = entity.PermanentAddress,
                Municipality = entity.Municipality,
                Ward = entity.Ward,
                Tole = entity.Tole,
                Occupation = entity.Occupation,
                DateOfBirth = entity.DateOfBirth,
                Age = entity.Age,
                Gender = entity.Gender,
                SubsidyDemandLetterFilePath = entity.SubsidyDemandLetterFilePath,
                PaperDocumentFilePath = entity.PaperDocumentFilePath,
                NeededAmount = entity.NeededAmount,
                GotAmount = entity.GotAmount,
                FundSettlementStatus = entity.FundSettlementStatus,
                BankName = entity.BankName,
                AccountName = entity.AccountName,
                AccountNumber = entity.AccountNumber,
                BankBranch = entity.BankBranch
            };
        }
    }
}
