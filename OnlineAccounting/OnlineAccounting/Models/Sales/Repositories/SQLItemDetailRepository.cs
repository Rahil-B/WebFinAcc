using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public class SQLItemDetailRepository:IItemDetailRepository
    {
        OnlineAccountingDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLItemDetailRepository(OnlineAccountingDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public ItemDetail Add(ItemDetail itemDetail)
        {
            context.itemDetails.Add(itemDetail);
            context.SaveChanges();
            return itemDetail;
        }

        public ItemDetail Delete(int Id)
        {
            ItemDetail itemDetail = context.itemDetails.Find(Id);
            if (itemDetail != null)
            {
                context.itemDetails.Remove(itemDetail);
                context.SaveChanges();
            }
            return itemDetail;
        }

        public IEnumerable<ItemDetail> GetAllItemDetails()
        {
            return context.itemDetails;
        }

        public IEnumerable<ItemDetail> GetAllItemDetailsBySalesOrderId(int id)
        {

            return context.itemDetails.Where(iDetail => iDetail.SalesOrderId == id).ToList();
        }

        public ItemDetail GetItemDetail(int Id)
        {
            return context.itemDetails.Find(Id);
        }

        public ItemDetail Update(ItemDetail itemDetailChanges)
        {
            var itemDetail = context.itemDetails.Attach(itemDetailChanges);
            itemDetail.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return itemDetailChanges;
        }
    }
}
