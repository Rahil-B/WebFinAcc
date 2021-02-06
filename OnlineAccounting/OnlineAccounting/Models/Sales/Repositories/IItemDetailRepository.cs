using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public interface IItemDetailRepository
    {
        ItemDetail GetItemDetail(int Id);
        IEnumerable<ItemDetail> GetAllItemDetails();
        public IEnumerable<ItemDetail> GetAllItemDetailsBySalesOrderId(int id);
        ItemDetail Add(ItemDetail itemDetail);
        ItemDetail Update(ItemDetail itemDetailChanged);
        ItemDetail Delete(int Id);
    }
}
