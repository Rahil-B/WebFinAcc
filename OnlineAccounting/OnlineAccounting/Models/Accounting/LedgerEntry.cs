using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Accounting
{
    public class LedgerEntry
    {
        public int Id { get; set; }
        public FinancialAccount Account { get; set; }
        /*public JournalEntry JournalEntry { get; set; }
        public int JournalEntryId { get; set; }*/
        public int AccountId { get; set; }
        public int TargetAccountId { get; set; }
        public LedgerEntryType type { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
