namespace NetWares.DTOs
{
    public class CreateTrainingDto
    {
        public string TrainingTitle { get; set; } = null!;
        public string TrainingCategory { get; set; } = null!;
        public string TrainerName { get; set; } = null!;
        public string TrainingAddress { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TrainingCost { get; set; }
        public int TrainingCapacity { get; set; }
    }

    public class UpdateTrainingDto
    {
        public int Id { get; set; }
        public string TrainingTitle { get; set; } = null!;
        public string TrainingCategory { get; set; } = null!;
        public string TrainerName { get; set; } = null!;
        public string TrainingAddress { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TrainingCost { get; set; }
        public int TrainingCapacity { get; set; }
    }

    public class ReadTrainingDto
    {
        public int Id { get; set; }
        public string TrainingTitle { get; set; } = null!;
        public string TrainingCategory { get; set; } = null!;
        public string TrainerName { get; set; } = null!;
        public string TrainingAddress { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TrainingCost { get; set; }
        public int TrainingCapacity { get; set; }
        public int DurationInDays 
        { 
            get => (EndDate - StartDate).Days + 1; 
        }
    }
}
