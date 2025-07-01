using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetWares.Dtos
{
    public class CreateSubsidyDto
    {
        public string Title { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal Amount { get; set; }
        public int Capacity { get; set; }
        public string FundSource { get; set; } = null!;
        public bool IsDuplicateAllow { get; set; }
        public bool IsInstallment { get; set; }
        public string Remarks { get; set; } = null!;
    }


    public class UpdateSubsidyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal Amount { get; set; }
        public int Capacity { get; set; }
        public string FundSource { get; set; } = null!;
        public bool IsDuplicateAllow { get; set; }
        public bool IsInstallment { get; set; }
        public string Remarks { get; set; } = null!;
    }
    
        public class ReadSubsidyDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal Amount { get; set; }
        public int Capacity { get; set; }
        public string FundSource { get; set; } = null!;
        public bool IsDuplicateAllow { get; set; }
        public bool IsInstallment { get; set; }
        public string Remarks { get; set; } = null!;
    }
}