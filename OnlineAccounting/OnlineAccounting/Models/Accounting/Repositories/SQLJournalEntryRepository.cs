using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Accounting.Repositories
{
    public class SQLJournalEntryRepository : IJournalEntryRepository
    {
        OnlineAccountingDbContext context;
        ILedgerEntryRepository ledgerEntryRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLJournalEntryRepository(OnlineAccountingDbContext context, ILedgerEntryRepository ledgerEntryRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.ledgerEntryRepository = ledgerEntryRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public JournalEntry Add(JournalEntry JournalEntry)
        {
            JournalEntry.userId = httpContextAccessor.HttpContext.User.Identity.Name;
            LedgerEntry cle = new LedgerEntry() {
                Id=0,
                AccountId=(int)JournalEntry.CreditAccountId,
                TargetAccountId=(int)JournalEntry.DebitAccountId,
                Amount=JournalEntry.Amount,
                Date=JournalEntry.Date,
                Description=JournalEntry.Description,
                type=LedgerEntryType.Credit
            };
            //ledgerEntryRepository.Add(cle);
            

            LedgerEntry dle = new LedgerEntry()
            {
                Id=0,
                AccountId = (int)JournalEntry.DebitAccountId,
                TargetAccountId = (int)JournalEntry.CreditAccountId,
                Amount = JournalEntry.Amount,
                Date = JournalEntry.Date,
                Description = JournalEntry.Description,
                type = LedgerEntryType.Debit
            };
            //ledgerEntryRepository.Add(dle);
            JournalEntry.CreditLedgerEntry = cle;
            JournalEntry.DebitLedgerEntry = dle;
            context.JournalEntries.Add(JournalEntry);
            context.SaveChanges();
            return JournalEntry;
        }

        public JournalEntry Delete(int Id)
        {
            JournalEntry JournalEntry = context.JournalEntries.Find(Id);
            if (JournalEntry != null && JournalEntry.userId== httpContextAccessor.HttpContext.User.Identity.Name)
            {
                ledgerEntryRepository.Delete(JournalEntry.CreditLedgerEntryId);
                ledgerEntryRepository.Delete(JournalEntry.DebitLedgerEntryId);
                context.JournalEntries.Remove(JournalEntry);
                context.SaveChanges();
                return JournalEntry;
            }
            return null;
        }

        public IEnumerable<JournalEntry> GetAllJournalEntries()
        {
            return context.JournalEntries.Include(j => j.CreditAccount).Include(j => j.DebitAccount).Where(je => je.userId == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public JournalEntry GetJournalEntry(int Id)
        {
            return context.JournalEntries.Include(j => j.CreditLedgerEntry).ThenInclude(l => l.Account).Include(j=>j.DebitLedgerEntry).ThenInclude(l => l.Account).FirstOrDefault(j => j.Id==Id && j.userId == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public JournalEntry Update(JournalEntry JournalEntryChanges)
        {
            if (JournalEntryChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name )
            {
                var JournalEntry = context.JournalEntries.Attach(JournalEntryChanges);
                JournalEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                JournalEntryChanges.CreditLedgerEntry.AccountId = (int)JournalEntryChanges.CreditAccountId;
                JournalEntryChanges.CreditLedgerEntry.TargetAccountId = (int)JournalEntryChanges.DebitAccountId;
                JournalEntryChanges.CreditLedgerEntry.Amount = JournalEntryChanges.Amount;
                JournalEntryChanges.CreditLedgerEntry.Date = JournalEntryChanges.Date;
                JournalEntryChanges.CreditLedgerEntry.Description = JournalEntryChanges.Description;
                JournalEntryChanges.CreditLedgerEntry.type = LedgerEntryType.Credit;
                ledgerEntryRepository.Update(JournalEntryChanges.CreditLedgerEntry);

                JournalEntryChanges.DebitLedgerEntry.AccountId = (int)JournalEntryChanges.DebitAccountId;
                JournalEntryChanges.DebitLedgerEntry.TargetAccountId = (int)JournalEntryChanges.CreditAccountId;
                JournalEntryChanges.DebitLedgerEntry.Amount = JournalEntryChanges.Amount;
                JournalEntryChanges.DebitLedgerEntry.Date = JournalEntryChanges.Date;
                JournalEntryChanges.DebitLedgerEntry.Description = JournalEntryChanges.Description;
                JournalEntryChanges.DebitLedgerEntry.type = LedgerEntryType.Debit;
                ledgerEntryRepository.Update(JournalEntryChanges.DebitLedgerEntry);

                context.SaveChanges();
                return JournalEntryChanges;
            }
            return null;
        }
    }
}
