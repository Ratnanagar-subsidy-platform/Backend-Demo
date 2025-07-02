using NetWares.DTOs;
using NetWares.Models;

namespace NetWares.Mappers
{
    public static class TrainingParticipantMapper
    {
        public static TrainingParticipant ToEntity(this CreateTrainingParticipantDto dto)
        {
            return new TrainingParticipant
            {
                TrainingTitle = dto.TrainingTitle,
                TrainingId = dto.TrainingId,
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
                DateOfBirth = dto.DateOfBirth.ToUniversalTime(),
                Gender = dto.Gender,
            };
        }

        public static void UpdateEntity(this TrainingParticipant entity, UpdateTrainingParticipantDto dto)
        {
            entity.TrainingTitle = dto.TrainingTitle;
            entity.FullName = dto.FullName;
            entity.CitizenshipNumber = dto.CitizenshipNumber;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.Email = dto.Email;
            entity.TemporaryAddress = dto.TemporaryAddress;
            entity.PermanentAddress = dto.PermanentAddress;
            entity.Municipality = dto.Municipality;
            entity.Ward = dto.Ward;
            entity.Tole = dto.Tole;
            entity.TrainingId = dto.TrainingId;
            entity.Occupation = dto.Occupation;
            entity.DateOfBirth = dto.DateOfBirth.ToUniversalTime();
            entity.Gender = dto.Gender;
            entity.CalculateAge();
        }

        public static ReadTrainingParticipantDto ToReadDto(this TrainingParticipant entity)
        {
            return new ReadTrainingParticipantDto
            {
                Id = entity.Id,
                TrainingId = entity.TrainingId,
                TrainingTitle = entity.TrainingTitle,
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
                Gender = entity.Gender
            };
        }
    }
}
