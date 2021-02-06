using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public class SQLPOrderItemDetailRepository:IPOrderItemDetailRepository
    {
        OnlineAccountingDbContext context;
        public SQLPOrderItemDetailRepository(OnlineAccountingDbContext context)
        {
            this.context = context;
        }
        public POrderItemDetail Add(POrderItemDetail pOrderItemDetail)
        {
            context.POrderItemDetails.Add(pOrderItemDetail);
            context.SaveChanges();
            return pOrderItemDetail;
        }

        public POrderItemDetail Delete(int Id)
        {
            POrderItemDetail pOrderItemDetail = context.POrderItemDetails.Find(Id);
            if (pOrderItemDetail != null)
            {
                context.POrderItemDetails.Remove(pOrderItemDetail);
                context.SaveChanges();
            }
            return pOrderItemDetail;
        }

        public IEnumerable<POrderItemDetail> GetAllPOrderItemDetails()
        {
            return context.POrderItemDetails;
        }

        public IEnumerable<POrderItemDetail> GetAllPOrderItemDetailByPOrderId(int POrderId)
        {
            return context.POrderItemDetails.Where(pd => pd.PurchaseOrderId == POrderId).ToList();
        }

        public POrderItemDetail GetPOrderItemDetail(int Id)
        {
            return context.POrderItemDetails.Find(Id);
        }

        public POrderItemDetail Update(POrderItemDetail pOrderItemDetailChanges)
        {
            var pOrderItemDetail = context.POrderItemDetails.Attach(pOrderItemDetailChanges);
            pOrderItemDetail.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            
            context.SaveChanges();
            return pOrderItemDetailChanges;
        }
    }
}
