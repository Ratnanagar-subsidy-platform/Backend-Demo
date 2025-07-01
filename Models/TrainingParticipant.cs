namespace NetWares.Models
{
    public class TrainingParticipant
    {
        public int Id { get; set; }
        public required string TrainingTitle { get; set; }

        public required string FullName { get; set; }
        public required string CitizenshipNumber { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Email { get; set; } = string.Empty;
        public required string TemporaryAddress { get; set; }
        public required string PermanentAddress { get; set; }
        public required string Municipality { get; set; }
        public required string Ward { get; set; }
        public required string Tole { get; set; }

        public required string Occupation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; private set; }
        public required string Gender { get; set; }

        public TrainingParticipant()
        {
            this.CalculateAge();
        }

        public void CalculateAge()
        {
            var today = DateTime.Today;
            this.Age = today.Year - DateOfBirth.Year;
        }

    }
}