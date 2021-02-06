using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Accounting
{
    public class JournalEntry
    {
        public int Id { get; set; }

        public string userId { get; set; }
        public FinancialAccount DebitAccount { get; set; }
        
        public int? DebitAccountId { get; set; }

        public FinancialAccount CreditAccount { get; set; }
        
        public int? CreditAccountId { get; set; }

        public string Description { get; set; }

        public string ReferanceId { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public LedgerEntry CreditLedgerEntry { get; set; }
        public int CreditLedgerEntryId { get; set; }

        public LedgerEntry DebitLedgerEntry { get; set; }
        public int DebitLedgerEntryId { get; set; }

    }
}
