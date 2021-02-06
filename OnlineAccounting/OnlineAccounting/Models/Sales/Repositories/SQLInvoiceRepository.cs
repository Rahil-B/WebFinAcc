using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public class SQLInvoiceRepository:IInvoiceRepository
    {
        readonly OnlineAccountingDbContext context;
        readonly ISalesOrderRepository salesOrderRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLInvoiceRepository(OnlineAccountingDbContext context, ISalesOrderRepository salesOrderRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.salesOrderRepository = salesOrderRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Invoice Add(Invoice invoice)
        {
            invoice.SalesOrder = salesOrderRepository.GetSalesOrder(invoice.SalesOrderId);
            if(invoice.SalesOrder.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.invoices.Add(invoice);
                context.SaveChanges();
                return invoice;
            }
            return null;
        }

        public Invoice Delete(int Id)
        {
            Invoice invoice = context.invoices.Include(i => i.SalesOrder).FirstOrDefault(i => i.Id == Id);
            if (invoice != null && invoice.SalesOrder.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.invoices.Remove(invoice);
                context.SaveChanges();
                return invoice;
            }
            return null;
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return context.invoices.Include(i => i.SalesOrder).Where(i => i.SalesOrder.userId == httpContextAccessor.HttpContext.User.Identity.Name).ToList();
        }

        public Invoice GetInvoice(int Id)
        {
            Invoice invoice = context.invoices.Include(i => i.SalesOrder).FirstOrDefault(i => i.Id == Id);
            if (invoice == null || invoice.SalesOrder.userId != httpContextAccessor.HttpContext.User.Identity.Name)
            {
                return null;
            }
            invoice.SalesOrder = salesOrderRepository.GetSalesOrder(invoice.SalesOrderId);
            return invoice;
        }

        public Invoice Update(Invoice invoiceChanges)
        {
            invoiceChanges.SalesOrder = salesOrderRepository.GetSalesOrder(invoiceChanges.SalesOrderId);
            if (invoiceChanges.SalesOrder.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var invoice = context.invoices.Attach(invoiceChanges);
                invoice.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return invoiceChanges;
            }
            return null;
        }
    }
}
