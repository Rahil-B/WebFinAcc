using OnlineAccounting.Models.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public DateTime Date { get; set; }
        public Vendor vendor { get; set; }
        [Required]
        public int VendorId { get; set; }
        public string DeliverTo { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }   /* Sub*(1 - discount/100) */
        public int TotalItems { get; set; }
        public IList<POrderItemDetail> ItemList { get; set; }
        void setTotal()
        {
            Total = SubTotal * (100 - Discount) / 100;
        }
    }
}
