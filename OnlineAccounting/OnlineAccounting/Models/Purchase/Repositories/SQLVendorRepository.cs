using Microsoft.AspNetCore.Http;
using OnlineAccounting.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public class SQLVendorRepository:IVendorRepository
    {
        OnlineAccountingDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IFinancialAccountRepository financialAccountRepository;

        public SQLVendorRepository(OnlineAccountingDbContext context, IHttpContextAccessor httpContextAccessor,IFinancialAccountRepository financialAccountRepository)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.financialAccountRepository = financialAccountRepository;
        }
        public Vendor Add(Vendor vendor)
        {
            FinancialAccount fa = new FinancialAccount()
            {
                AccountCode = "V-" + vendor.Name,
                Name = vendor.Name ,
                CreditBalance = 0,
                DebitBalance = 0,
                Type = PrimaryAccountType.Liability,
                UserId = httpContextAccessor.HttpContext.User.Identity.Name
            };
            financialAccountRepository.Add(fa);
            vendor.FinancialAccountId = fa.Id;
            vendor.userId = httpContextAccessor.HttpContext.User.Identity.Name;
            context.vendors.Add(vendor);
            context.SaveChanges();
            return vendor;
        }

        public Vendor Delete(int Id)
        {
            Vendor vendor = context.vendors.Find(Id);
            if (vendor != null && vendor.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                financialAccountRepository.Delete(vendor.FinancialAccountId);
                context.vendors.Remove(vendor);
                context.SaveChanges();
                return vendor;
            }
            return null;
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            return context.vendors.Where(v => v.userId == httpContextAccessor.HttpContext.User.Identity.Name).ToList();
        }

        public Vendor GetVendor(int Id)
        {
            return context.vendors.Where(v => v.userId == httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(v => v.Id == Id);
        }

        public Vendor Update(Vendor vendorChanges)
        {
            if(vendorChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var vendor = context.vendors.Attach(vendorChanges);
                vendor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return vendorChanges;
            }
            return null;
        }
    }
}
