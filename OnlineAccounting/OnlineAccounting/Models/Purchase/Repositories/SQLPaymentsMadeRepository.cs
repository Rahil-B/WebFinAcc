using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public class SQLPaymentsMadeRepository:IPaymentsMadeRepository
    {
        OnlineAccountingDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLPaymentsMadeRepository(OnlineAccountingDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public PaymentsMade Add(PaymentsMade paymentsMade)
        {
            paymentsMade.userId = httpContextAccessor.HttpContext.User.Identity.Name;
            JournalEntry journalEntry = new JournalEntry()
            {
                Amount = paymentsMade.Amount,
                Date= paymentsMade.Date,
                Description = "Payment Made",
                ReferanceId = paymentsMade.ReceiptReferance,
                CreditAccountId=paymentsMade.PaymentToAccountId,
                DebitAccountId = paymentsMade.PaymentFromAccountId,
                userId = paymentsMade.userId
            };
            context.paymentsMades.Add(paymentsMade);
            context.SaveChanges();
            return paymentsMade;
        }

        public PaymentsMade Delete(int Id)
        {
            PaymentsMade paymentsMade = context.paymentsMades.Find(Id);
            if (paymentsMade != null && paymentsMade.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.paymentsMades.Remove(paymentsMade);
                context.SaveChanges();
                return paymentsMade;
            }
            return null;
        }

        public IEnumerable<PaymentsMade> GetAllPaymentsMades()
        {
            return context.paymentsMades.Include(pm => pm.Vendor).Where(pm => pm.userId == httpContextAccessor.HttpContext.User.Identity.Name).ToList();
        }

        public PaymentsMade GetPaymentsMade(int Id)
        {
            return context.paymentsMades.Include(pm => pm.Vendor).Where(pm => pm.userId == httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(pm => pm.Id == Id);
        }

        public PaymentsMade Update(PaymentsMade paymentsMadeChanges)
        {
            if (paymentsMadeChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var paymentsMade = context.paymentsMades.Attach(paymentsMadeChanges);
                paymentsMade.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return paymentsMadeChanges;
            }
            return null;
        }
    }
}
