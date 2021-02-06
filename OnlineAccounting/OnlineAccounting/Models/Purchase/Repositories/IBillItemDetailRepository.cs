using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public interface IBillItemDetailRepository
    {
        BillItemDetail GetBillItemDetail(int Id);
        IEnumerable<BillItemDetail> GetAllBillItemDetails();
        IEnumerable<BillItemDetail> GetAllBillItemDetailByBillId(int BillId);
        BillItemDetail Add(BillItemDetail billItemDetail);
        BillItemDetail Update(BillItemDetail billItemDetailChanged);
        BillItemDetail Delete(int Id);
    }
}
