using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoice(int Id);
        IEnumerable<Invoice> GetAllInvoices();
        Invoice Add(Invoice invoice);
        Invoice Update(Invoice invoiceChanged);
        Invoice Delete(int Id);
    }
}
