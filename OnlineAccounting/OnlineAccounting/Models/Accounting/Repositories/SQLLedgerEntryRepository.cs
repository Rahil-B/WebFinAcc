using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Accounting.Repositories
{
    public class SQLLedgerEntryRepository:ILedgerEntryRepository
    {
        OnlineAccountingDbContext context;
        IFinancialAccountRepository financialAccountRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLLedgerEntryRepository(OnlineAccountingDbContext context, IFinancialAccountRepository financialAccountRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.financialAccountRepository = financialAccountRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public LedgerEntry Add(LedgerEntry LedgerEntry)
        {
            if (LedgerEntry.type == LedgerEntryType.Credit)
            {
                LedgerEntry.Account = financialAccountRepository.GetFinancialAccount(LedgerEntry.AccountId);
                if(LedgerEntry.Account == null)
                {
                    return null;
                }
                LedgerEntry.Account.CreditBalance += LedgerEntry.Amount;
                financialAccountRepository.Update(LedgerEntry.Account);
            }
            else if (LedgerEntry.type == LedgerEntryType.Debit)
            {
                LedgerEntry.Account = financialAccountRepository.GetFinancialAccount(LedgerEntry.AccountId);
                if (LedgerEntry.Account == null)
                {
                    return null;
                }
                LedgerEntry.Account.DebitBalance += LedgerEntry.Amount;
                financialAccountRepository.Update(LedgerEntry.Account);
            }
            context.LedgerEntries.Add(LedgerEntry);
            context.SaveChanges();
            return LedgerEntry;
        }

        public LedgerEntry Delete(int Id)
        {
            LedgerEntry LedgerEntry = context.LedgerEntries.Find(Id);
            if (LedgerEntry != null)
            {
                context.LedgerEntries.Remove(LedgerEntry);
                context.SaveChanges();
            }
            return LedgerEntry;
        }

        public IEnumerable<LedgerEntry> GetAllLedgerEntries()
        {
            return context.LedgerEntries.Include(le => le.Account).Where(le=> le.Account.UserId == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public IEnumerable<LedgerEntry> GetAllLedgerEntriesByAccountId(int id)
        {
            return context.LedgerEntries.Where(le => le.AccountId == id).ToList();
        }

        public LedgerEntry GetLedgerEntry(int Id)
        {
            return context.LedgerEntries.Include(le => le.Account).Where(le => le.Account.UserId == httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(le => le.Id==Id);
        }

        public LedgerEntry Update(LedgerEntry LedgerEntryChanges)
        {
            var OldLedgerEntry = GetLedgerEntry(LedgerEntryChanges.Id);
            if (LedgerEntryChanges.type == LedgerEntryType.Credit)
            {
                LedgerEntryChanges.Account = financialAccountRepository.GetFinancialAccount(LedgerEntryChanges.AccountId);
                if (LedgerEntryChanges.Account == null)
                {
                    return null;
                }
                LedgerEntryChanges.Account.CreditBalance -= OldLedgerEntry.Amount;
                LedgerEntryChanges.Account.CreditBalance += LedgerEntryChanges.Amount;
                financialAccountRepository.Update(LedgerEntryChanges.Account);
            }
            else if (LedgerEntryChanges.type == LedgerEntryType.Debit)
            {
                LedgerEntryChanges.Account = financialAccountRepository.GetFinancialAccount(LedgerEntryChanges.AccountId);
                if (LedgerEntryChanges.Account == null)
                {
                    return null;
                }
                LedgerEntryChanges.Account.DebitBalance -= OldLedgerEntry.Amount;
                LedgerEntryChanges.Account.DebitBalance += LedgerEntryChanges.Amount;
                financialAccountRepository.Update(LedgerEntryChanges.Account);
            }

            var LedgerEntry = context.LedgerEntries.Attach(LedgerEntryChanges);
            LedgerEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return LedgerEntryChanges;
        }
    }
}
