

namespace NetWares.Models
{
    public class Subsidy
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Category { get; set; }
        public required decimal Amount { get; set; }
        public int Capacity { get; set; } // No. of people granted
        public required string FundSource { get; set; }
        public bool IsDuplicateAllow { get; set; }
        public bool IsInstallment { get; set; }
        public required string Remarks { get; set; }
        
        
    }
}