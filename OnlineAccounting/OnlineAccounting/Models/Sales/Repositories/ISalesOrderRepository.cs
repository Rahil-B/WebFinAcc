using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public interface ISalesOrderRepository
    {
        SalesOrder GetSalesOrder(int Id);
        IEnumerable<SalesOrder> GetAllSalesOrders();
        SalesOrder Add(SalesOrder salesOrder);
        SalesOrder Update(SalesOrder salesOrderChanged);
        SalesOrder Delete(int Id);
    }
}
