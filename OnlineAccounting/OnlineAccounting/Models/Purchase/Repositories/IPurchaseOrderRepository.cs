using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public interface IPurchaseOrderRepository
    {
        PurchaseOrder GetPurchaseOrder(int Id);
        IEnumerable<PurchaseOrder> GetAllPurchaseOrders();
        PurchaseOrder Add(PurchaseOrder purchaseOrder);
        PurchaseOrder Update(PurchaseOrder purchaseOrderChanged);
        PurchaseOrder Delete(int Id);
    }
}
