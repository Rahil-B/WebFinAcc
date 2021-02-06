using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public class SQLBillRepository:IBillRepository
    {
        OnlineAccountingDbContext context;
        IBillItemDetailRepository billItemDetailRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLBillRepository(OnlineAccountingDbContext context, IBillItemDetailRepository billItemDetailRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.billItemDetailRepository = billItemDetailRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Bill Add(Bill bill)
        {
            bill.userId = httpContextAccessor.HttpContext.User.Identity.Name;
            context.bills.Add(bill);
            context.SaveChanges();
            return bill;
        }

        public Bill Delete(int Id)
        {
            Bill bill = context.bills.Find(Id);
            
            bill.ItemList =(IList<BillItemDetail>) billItemDetailRepository.GetAllBillItemDetailByBillId(Id);
            if (bill != null && bill.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                foreach(BillItemDetail bi in bill.ItemList)
                {
                    context.billItemDetails.Remove(bi);
                }
                context.bills.Remove(bill);
                context.SaveChanges();
                return bill;
            }
            return null;
        }

        public IEnumerable<Bill> GetAllBills()
        {
            return context.bills.Include(b => b.vendor).Where(b => b.userId== httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public Bill GetBill(int Id)
        {
            return context.bills.Include(b => b.vendor).Where(b => b.userId == httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(b => b.Id==Id);
        }

        public Bill Update(Bill billChanges)
        {
            if(billChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var bill = context.bills.Attach(billChanges);
                bill.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                foreach (BillItemDetail bi in billChanges.ItemList)
                {
                    var tempBi = context.billItemDetails.Attach(bi);
                    tempBi.State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                }
                context.SaveChanges();
                return billChanges;
            }
            return null;
        }
    }
}
