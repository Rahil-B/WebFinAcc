using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Accounting.Repositories
{
    public interface ILedgerEntryRepository
    {
        LedgerEntry GetLedgerEntry(int Id);
        IEnumerable<LedgerEntry> GetAllLedgerEntries();
        public IEnumerable<LedgerEntry> GetAllLedgerEntriesByAccountId(int id);
        LedgerEntry Add(LedgerEntry ledgerEntry);
        LedgerEntry Update(LedgerEntry ledgerEntryChanged);
        LedgerEntry Delete(int Id);
    }
}
