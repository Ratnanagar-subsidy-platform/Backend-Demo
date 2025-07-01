

namespace NetWares.Models
{
    public class Training
    {
        public int Id { get; set; }
        public required string TrainingTitle { get; set; }
        public required string TrainingCategory { get; set; }
        public required string TrainerName { get; set; }
        public required string TrainingAddress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TrainingCost { get; set; }
        public int TrainingCapacity { get; set; }
        public int DurationInDays { get; }
        public Training()
        {
            DurationInDays = (EndDate - StartDate).Days + 1;
        }
    }
}