using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public interface IPaymentReceivedRepository
    {
        PaymentReceived GetPaymentReceived(int Id);
        IEnumerable<PaymentReceived> GetAllPaymentReceiveds();
        PaymentReceived Add(PaymentReceived paymentReceived);
        PaymentReceived Update(PaymentReceived paymentReceivedChanged);
        PaymentReceived Delete(int Id);
    }
}
