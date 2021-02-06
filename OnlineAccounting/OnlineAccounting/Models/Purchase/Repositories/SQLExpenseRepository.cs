using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models.Accounting;
using OnlineAccounting.Models.Accounting.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public class SQLExpenseRepository:IExpenseRepository
    {
        OnlineAccountingDbContext context;
        IJournalEntryRepository journalEntryRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLExpenseRepository(OnlineAccountingDbContext context, IJournalEntryRepository journalEntryRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.journalEntryRepository = journalEntryRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Expense Add(Expense expense)
        {
            JournalEntry tempJe = new JournalEntry()
            {
                userId = httpContextAccessor.HttpContext.User.Identity.Name,
                Amount = expense.Amount,
                Date = expense.Date,
                ReferanceId = expense.InvoiceReferance,
                Description = "Expense:"+expense.Description,
                CreditAccount=expense.PaidFromAccount,
                CreditAccountId=expense.PaidFromAccountId,
                DebitAccount=expense.ExpenseAccount,
                DebitAccountId=expense.ExpenseAccountId
            };
            
            var jentry = journalEntryRepository.Add(tempJe);
            expense.JournalEntry = jentry;
            expense.JournalEntryId = jentry.Id;
            context.expenses.Add(expense);
            context.SaveChanges();
            return expense;
        }

        public Expense Delete(int Id)
        {
            Expense expense = context.expenses.Find(Id);
            if (expense != null && expense.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.expenses.Remove(expense);
                context.SaveChanges();
                return expense;
            }
            return null;
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return context.expenses.Include(e => e.Vendor).Where(e => e.userId == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public Expense GetExpense(int Id)
        {
            return context.expenses.Include(e => e.Vendor).Include(e => e.JournalEntry).ThenInclude(j => j.CreditAccount).Include(e => e.JournalEntry).ThenInclude(j => j.DebitAccount).Where(e => e.userId == httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(b => b.Id==Id);
        }

        public Expense Update(Expense expenseChanges)
        {
            if (expenseChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                expenseChanges.JournalEntry = journalEntryRepository.GetJournalEntry(expenseChanges.JournalEntryId);
                expenseChanges.JournalEntry.Amount = expenseChanges.Amount;
                expenseChanges.JournalEntry.Date = expenseChanges.Date;
                expenseChanges.JournalEntry.ReferanceId = expenseChanges.InvoiceReferance;
                expenseChanges.JournalEntry.Description = expenseChanges.Description;
                expenseChanges.JournalEntry.userId = expenseChanges.userId;
                expenseChanges.JournalEntry.CreditAccount = expenseChanges.PaidFromAccount;
                expenseChanges.JournalEntry.CreditAccountId = expenseChanges.PaidFromAccountId;
                expenseChanges.JournalEntry.DebitAccount = expenseChanges.ExpenseAccount;
                expenseChanges.JournalEntry.DebitAccountId = expenseChanges.ExpenseAccountId;
                journalEntryRepository.Update(expenseChanges.JournalEntry);

                var expense = context.expenses.Attach(expenseChanges);
                expense.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                journalEntryRepository.Update(expenseChanges.JournalEntry);
                return expenseChanges;
            }
            return null;
        }
    }
}
