using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public class SQLSalesOrderRepository:ISalesOrderRepository
    {
        OnlineAccountingDbContext context;
        IItemDetailRepository itemDetailRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLSalesOrderRepository(OnlineAccountingDbContext context, IItemDetailRepository itemDetailRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.itemDetailRepository = itemDetailRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public SalesOrder Add(SalesOrder salesOrder)
        {
            salesOrder.userId = httpContextAccessor.HttpContext.User.Identity.Name;
            context.salesOrders.Add(salesOrder);
            context.SaveChanges();
            return salesOrder;
        }

        public SalesOrder Delete(int Id)
        {
            SalesOrder salesOrder = context.salesOrders.Find(Id);
            if (salesOrder != null && salesOrder.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.salesOrders.Remove(salesOrder);
                context.SaveChanges();
                return salesOrder;
            }
            return null;
        }

        public IEnumerable<SalesOrder> GetAllSalesOrders()
        {
            return context.salesOrders.Where(so => so.userId == httpContextAccessor.HttpContext.User.Identity.Name).ToList();
        }

        public SalesOrder GetSalesOrder(int Id)
        {
            SalesOrder salesOrder = context.salesOrders.Find(Id);
            if(salesOrder == null || salesOrder.userId!= httpContextAccessor.HttpContext.User.Identity.Name)
            {
                return null;
            }
            salesOrder.ItemList = context.itemDetails.Where(i => i.SalesOrderId == salesOrder.Id).ToList();
            return salesOrder;
        }

        public SalesOrder Update(SalesOrder salesOrderChanges)
        {
            if (salesOrderChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var salesOrder = context.salesOrders.Attach(salesOrderChanges);
                salesOrder.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                foreach (ItemDetail i in salesOrderChanges.ItemList)
                {
                    itemDetailRepository.Update(i);
                }
                context.SaveChanges();
                return salesOrderChanges;
            }
            return null;
        }
    }
}
