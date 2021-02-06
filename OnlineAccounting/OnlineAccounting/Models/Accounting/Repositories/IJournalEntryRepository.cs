using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Accounting.Repositories
{
    public interface IJournalEntryRepository
    {
        JournalEntry GetJournalEntry(int Id);
        IEnumerable<JournalEntry> GetAllJournalEntries();
        JournalEntry Add(JournalEntry journalEntry);
        JournalEntry Update(JournalEntry journalEntryChanged);
        JournalEntry Delete(int Id);
    }
}
