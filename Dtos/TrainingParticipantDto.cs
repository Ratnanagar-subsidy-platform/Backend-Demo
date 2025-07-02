namespace NetWares.DTOs
{
    public class CreateTrainingParticipantDto
    {
        public int TrainingId { get; set; }
        public string TrainingTitle { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string CitizenshipNumber { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; } = string.Empty;
        public string TemporaryAddress { get; set; } = null!;
        public string PermanentAddress { get; set; } = null!;
        public string Municipality { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public string Tole { get; set; } = null!;
        public string Occupation { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
    }

    public class UpdateTrainingParticipantDto
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public string TrainingTitle { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string CitizenshipNumber { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; } = string.Empty;
        public string TemporaryAddress { get; set; } = null!;
        public string PermanentAddress { get; set; } = null!;
        public string Municipality { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public string Tole { get; set; } = null!;
        public string Occupation { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
    }

    public class ReadTrainingParticipantDto
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public string TrainingTitle { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string CitizenshipNumber { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; } = string.Empty;
        public string TemporaryAddress { get; set; } = null!;
        public string PermanentAddress { get; set; } = null!;
        public string Municipality { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public string Tole { get; set; } = null!;
        public string Occupation { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
    }
}
