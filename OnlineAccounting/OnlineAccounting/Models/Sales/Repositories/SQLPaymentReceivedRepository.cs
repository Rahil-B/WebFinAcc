using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public class SQLPaymentReceivedRepository:IPaymentReceivedRepository
    {
        OnlineAccountingDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLPaymentReceivedRepository(OnlineAccountingDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public PaymentReceived Add(PaymentReceived paymentReceived)
        {
            paymentReceived.userId = httpContextAccessor.HttpContext.User.Identity.Name;
            context.paymentReceiveds.Add(paymentReceived);
            context.SaveChanges();
            return paymentReceived;
        }

        public PaymentReceived Delete(int Id)
        {
            PaymentReceived paymentReceived = context.paymentReceiveds.Find(Id);
            if (paymentReceived != null && paymentReceived.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.paymentReceiveds.Remove(paymentReceived);
                context.SaveChanges();
            }
            return paymentReceived;
        }

        public IEnumerable<PaymentReceived> GetAllPaymentReceiveds()
        {
            return context.paymentReceiveds.Include(p => p.DepositedToAccount).Where(pr => pr.userId == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public PaymentReceived GetPaymentReceived(int Id)
        {
            return context.paymentReceiveds.Include(p => p.DepositedToAccount).Where(pr => pr.userId == httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(pr => pr.Id == Id);
        }

        public PaymentReceived Update(PaymentReceived paymentReceivedChanges)
        {
            if(paymentReceivedChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var paymentReceived = context.paymentReceiveds.Attach(paymentReceivedChanges);
                paymentReceived.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return paymentReceivedChanges;
            }
            return null;
        }
    }
}
