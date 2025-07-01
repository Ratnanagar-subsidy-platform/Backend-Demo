using NetWares.DTOs;
using NetWares.Models;

namespace NetWares.Mappers
{
    public static class TrainingMapper
    {
        public static Training ToEntity(this CreateTrainingDto dto)
        {
            return new Training
            {
                TrainingTitle = dto.TrainingTitle,
                TrainingCategory = dto.TrainingCategory,
                TrainerName = dto.TrainerName,
                TrainingAddress = dto.TrainingAddress,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TrainingCost = dto.TrainingCost,
                TrainingCapacity = dto.TrainingCapacity
            };
        }

        public static void UpdateEntity(this Training entity, UpdateTrainingDto dto)
        {
            entity.TrainingTitle = dto.TrainingTitle;
            entity.TrainingCategory = dto.TrainingCategory;
            entity.TrainerName = dto.TrainerName;
            entity.TrainingAddress = dto.TrainingAddress;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.TrainingCost = dto.TrainingCost;
            entity.TrainingCapacity = dto.TrainingCapacity;
        }

        public static ReadTrainingDto ToReadDto(this Training entity)
        {
            return new ReadTrainingDto
            {
                Id = entity.Id,
                TrainingTitle = entity.TrainingTitle,
                TrainingCategory = entity.TrainingCategory,
                TrainerName = entity.TrainerName,
                TrainingAddress = entity.TrainingAddress,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                TrainingCost = entity.TrainingCost,
                TrainingCapacity = entity.TrainingCapacity
            };
        }
    }
}
