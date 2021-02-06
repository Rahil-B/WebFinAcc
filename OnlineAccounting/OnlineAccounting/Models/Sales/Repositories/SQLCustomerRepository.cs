using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public class SQLCustomerRepository:ICustomerRepository
    {
        OnlineAccountingDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLCustomerRepository(OnlineAccountingDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Customer Add(Customer customer)
        {
            customer.userId = httpContextAccessor.HttpContext.User.Identity.Name;
            context.customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public Customer Delete(int Id)
        {
            Customer customer = context.customers.Find(Id);
            if (customer != null && customer.userId== httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.customers.Remove(customer);
                context.SaveChanges();
                return customer;
            }
            return null;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.customers.Where(c => c.userId == httpContextAccessor.HttpContext.User.Identity.Name).ToList();
        }

        public Customer GetCustomer(int Id)
        {
            return context.customers.Where(c => c.userId == httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(c => c.Id == Id);
        }

        public Customer Update(Customer customerChanges)
        {
            if(customerChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var customer = context.customers.Attach(customerChanges);
                customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return customerChanges;
            }
            return null;
        }
    }
}
