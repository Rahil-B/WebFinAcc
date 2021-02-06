using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase
{
    public class PaymentsMade
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public FinancialAccount PaymentFromAccount { get; set; }
        public int PaymentFromAccountId { get; set; }

        public FinancialAccount PaymentToAccount { get; set; }
        public int PaymentToAccountId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public PaymentMode Mode { get; set; }
        public string ReceiptReferance { get; set; }
        public IList<Bill> ReferanceBills { get; set; }
    }
}
