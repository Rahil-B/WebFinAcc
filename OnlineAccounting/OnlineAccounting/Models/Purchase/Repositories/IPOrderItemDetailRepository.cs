using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public interface IPOrderItemDetailRepository
    {
        POrderItemDetail GetPOrderItemDetail(int Id);
        IEnumerable<POrderItemDetail> GetAllPOrderItemDetails();
        IEnumerable<POrderItemDetail> GetAllPOrderItemDetailByPOrderId(int Id);
        POrderItemDetail Add(POrderItemDetail POrderItemDetail);
        POrderItemDetail Update(POrderItemDetail POrderItemDetailChanged);
        POrderItemDetail Delete(int Id);
    }
}
