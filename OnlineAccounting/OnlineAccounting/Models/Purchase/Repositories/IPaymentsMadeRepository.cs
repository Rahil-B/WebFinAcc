using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public interface IPaymentsMadeRepository
    {
        PaymentsMade GetPaymentsMade(int Id);
        IEnumerable<PaymentsMade> GetAllPaymentsMades();
        PaymentsMade Add(PaymentsMade paymentsMade);
        PaymentsMade Update(PaymentsMade paymentsMadeChanged);
        PaymentsMade Delete(int Id);
    }
}
