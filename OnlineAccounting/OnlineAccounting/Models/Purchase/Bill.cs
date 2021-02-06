using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase
{
    public class Bill
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public Vendor vendor { get; set; }
        public int VendorId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double TDS { get; set; }
        public double Total { get; set; }
        //public PaymentsMade? Payment { get; set; }
        
        public int PaymentId { get; set; }
        public IList<BillItemDetail> ItemList { get; set; }

    }
}
