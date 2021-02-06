using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public class SQLPurchaseOrderRepository:IPurchaseOrderRepository
    {
        OnlineAccountingDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLPurchaseOrderRepository(OnlineAccountingDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public PurchaseOrder Add(PurchaseOrder purchaseOrder)
        {
            purchaseOrder.userId = httpContextAccessor.HttpContext.User.Identity.Name;
            purchaseOrder.Id = 0;
            if (purchaseOrder.TotalItems == 0)
            {
                purchaseOrder.TotalItems = purchaseOrder.ItemList.Count;
            }
            context.purchaseOrders.Add(purchaseOrder);
            context.SaveChanges();
            return purchaseOrder;
        }

        public PurchaseOrder Delete(int Id)
        {
            PurchaseOrder purchaseOrder = context.purchaseOrders.Find(Id);
            if (purchaseOrder != null && purchaseOrder.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.purchaseOrders.Remove(purchaseOrder);
                context.SaveChanges();
            }
            return purchaseOrder;
        }

        public IEnumerable<PurchaseOrder> GetAllPurchaseOrders()
        {
            return context.purchaseOrders.Include(p => p.vendor).Where(po => po.userId == httpContextAccessor.HttpContext.User.Identity.Name).ToList();
        }

        public PurchaseOrder GetPurchaseOrder(int Id)
        {
            return context.purchaseOrders.Include(p => p.vendor).Where(po => po.userId == httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(po => po.Id == Id);
        }

        public PurchaseOrder Update(PurchaseOrder purchaseOrderChanges)
        {
            if(purchaseOrderChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var purchaseOrder = context.purchaseOrders.Attach(purchaseOrderChanges);
                purchaseOrder.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                foreach (POrderItemDetail pd in purchaseOrderChanges.ItemList)
                {
                    /* for optimized update we have prevented the used Update method of POrderItemDetailRepository 
                     i.e to prevent multiple times context.SaveChanges();
                        and in a try to make PurchaseOrder Update an atomic transaction
                     */
                    var tempPd = context.POrderItemDetails.Attach(pd);
                    tempPd.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return purchaseOrderChanges;
            }
            return null;
        }
    }
}
