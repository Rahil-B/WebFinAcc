using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public interface IDeliveryChallanRepository
    {
        DeliveryChallan GetDeliveryChallan(int Id);
        IEnumerable<DeliveryChallan> GetAllDeliveryChallans();
        DeliveryChallan Add(DeliveryChallan deliveryChallan);
        DeliveryChallan Update(DeliveryChallan deliveryChallanChanged);
        DeliveryChallan Delete(int Id);
    }
}
