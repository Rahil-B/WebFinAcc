using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models.Accounting;
using OnlineAccounting.Models.Accounting.Repositories;
using OnlineAccounting.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Repositories
{
    public class SQLFinancialAccountRepository : IFinancialAccountRepository
    {
        OnlineAccountingDbContext context;
        //private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLFinancialAccountRepository(OnlineAccountingDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            //this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }
        public FinancialAccount Add(FinancialAccount financialAccount)
        {
            financialAccount.UserId = httpContextAccessor.HttpContext.User.Identity.Name;
            context.FinancialAccounts.Add(financialAccount);
            context.SaveChanges();
            return financialAccount;
        }

        public FinancialAccount Delete(int Id)
        {
            FinancialAccount financialAccount = context.FinancialAccounts.Find(Id);
            if (financialAccount != null && financialAccount.UserId== httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.FinancialAccounts.Remove(financialAccount);
                context.SaveChanges();
                return financialAccount;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<FinancialAccount> GetAllFinancialAccounts()
        {
            return context.FinancialAccounts.Where(fa => fa.UserId == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public FinancialAccount GetFinancialAccount(int Id)
        {
            FinancialAccount fa = context.FinancialAccounts.Find(Id);
            fa.LedgerEntries = context.LedgerEntries.Include(le => le.Account).Where(le => le.AccountId == Id && le.Account.UserId== httpContextAccessor.HttpContext.User.Identity.Name).ToList();
            return fa;
        }

        public FinancialAccount Update(FinancialAccount financialAccountChanges)
        {
            if (financialAccountChanges.UserId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var financialAccount = context.FinancialAccounts.Attach(financialAccountChanges);
                financialAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return financialAccountChanges;
            }
            return null;
        }
    }
}
