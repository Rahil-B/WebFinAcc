using OnlineAccounting.Models.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models
{
    public class FinancialAccount
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
        public string Name { get; set; }
        [Required]
        public PrimaryAccountType Type { get; set; }
        
        public string AccountCode { get; set; }
        public double DebitBalance { get; set; }
        public double CreditBalance { get; set; }

        public IList<LedgerEntry> LedgerEntries { get; set; }
        /*
        public IList<JournalEntry> DebitJournalEntries { get; set; }
        public IList<JournalEntry> CreditJournalEntries { get; set; }
        */
    }
}
