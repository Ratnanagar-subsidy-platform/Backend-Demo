

namespace NetWares.Models
{
    public class SubsidyEntry
    {

        public int Id { get; set; }
        public required int SubsidyId { get; set; }
        public string SubsidyTitle { get; set; } = null!;
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

        public int Age { get; set; }

        public required string Gender { get; set; }

        public required string SubsidyDemandLetterFilePath { get; set; }
        public required string PaperDocumentFilePath { get; set; }

        public decimal NeededAmount { get; set; }
        public decimal GotAmount { get; set; } = 0;

        public required string FundSettlementStatus { get; set; }

        public required string BankName { get; set; }
        public required string AccountName { get; set; }
        public required string AccountNumber { get; set; }
        public required string BankBranch { get; set; }


        public SubsidyEntry()
        {
            this.CalculateAge();
        }

        public void CalculateAge()
        {
            var today = DateTime.Today;
            Age = today.Year - DateOfBirth.Year;
        }
    }
}