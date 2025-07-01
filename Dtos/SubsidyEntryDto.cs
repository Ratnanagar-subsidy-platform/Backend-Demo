namespace NetWares.DTOs
{
    public class CreateSubsidyEntryDto
    {
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

        public string SubsidyDemandLetterFilePath { get; set; } = null!;
        public string PaperDocumentFilePath { get; set; } = null!;

        public decimal NeededAmount { get; set; }
        public decimal GotAmount { get; set; } = 0;

        public string FundSettlementStatus { get; set; } = null!;

        public string BankName { get; set; } = null!;
        public string AccountName { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public string BankBranch { get; set; } = null!;
    }

    public class UpdateSubsidyEntryDto
    {
        public int Id { get; set; }
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

        public string SubsidyDemandLetterFilePath { get; set; } = null!;
        public string PaperDocumentFilePath { get; set; } = null!;

        public decimal NeededAmount { get; set; }
        public decimal GotAmount { get; set; }

        public string FundSettlementStatus { get; set; } = null!;

        public string BankName { get; set; } = null!;
        public string AccountName { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public string BankBranch { get; set; } = null!;
    }

    public class ReadSubsidyEntryDto
    {
        public int Id { get; set; }
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

        public string SubsidyDemandLetterFilePath { get; set; } = null!;
        public string PaperDocumentFilePath { get; set; } = null!;

        public decimal NeededAmount { get; set; }
        public decimal GotAmount { get; set; }

        public string FundSettlementStatus { get; set; } = null!;

        public string BankName { get; set; } = null!;
        public string AccountName { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public string BankBranch { get; set; } = null!;
    }
}
