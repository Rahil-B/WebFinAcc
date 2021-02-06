using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public interface IBillRepository
    {
        Bill GetBill(int Id);
        IEnumerable<Bill> GetAllBills();
        Bill Add(Bill bill);
        Bill Update(Bill billChanged);
        Bill Delete(int Id);
    }
}
