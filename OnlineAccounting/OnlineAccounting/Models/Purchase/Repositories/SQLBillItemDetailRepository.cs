using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public class SQLBillItemDetailRepository:IBillItemDetailRepository
    {
        OnlineAccountingDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLBillItemDetailRepository(OnlineAccountingDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public BillItemDetail Add(BillItemDetail BillItemDetail)
        {
            context.billItemDetails.Add(BillItemDetail);
            context.SaveChanges();
            return BillItemDetail;
        }

        public BillItemDetail Delete(int Id)
        {
            BillItemDetail BillItemDetail = context.billItemDetails.Include(b => b.bill).FirstOrDefault(b => b.Id == Id && b.bill.userId == httpContextAccessor.HttpContext.User.Identity.Name);
            if (BillItemDetail != null)
            {
                context.billItemDetails.Remove(BillItemDetail);
                context.SaveChanges();
            }
            return BillItemDetail;
        }

        public IEnumerable<BillItemDetail> GetAllBillItemDetails()
        {
            return context.billItemDetails
                .Include(bi => bi.Account)
                .Include(bi => bi.customer)
                .Include(bi => bi.bill)
                .Include(bi => bi.item)
                .Where(b => b.bill.userId == httpContextAccessor.HttpContext.User.Identity.Name).ToList();
        }

        public BillItemDetail GetBillItemDetail(int Id)
        {
            return context.billItemDetails
                .Include(bi => bi.Account)
                .Include(bi => bi.customer)
                .Include(bi => bi.item)
                .Include(bi => bi.bill)
                .Where(b => b.bill.userId == httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(b => b.Id==Id);
        }
        public IEnumerable<BillItemDetail> GetAllBillItemDetailByBillId(int BillId)
        {
            
            return context.billItemDetails
                .Include(bi => bi.Account)
                .Include(bi => bi.customer)
                .Include(bi => bi.item)
                .Where(b => b.BillId == BillId && b.bill.userId == httpContextAccessor.HttpContext.User.Identity.Name ).ToList();
        }

        public BillItemDetail Update(BillItemDetail billItemDetailChanges)
        {
            var billItemDetail= context.billItemDetails.Attach(billItemDetailChanges);
            billItemDetail.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return billItemDetailChanges;
        }
    }
}
