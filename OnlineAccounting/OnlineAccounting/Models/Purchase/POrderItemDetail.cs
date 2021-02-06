using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase
{
    public class POrderItemDetail
    {
        public int Id { get; set; }
        public PurchaseOrder purchaseOrder { get; set; }
        public int PurchaseOrderId { get; set; }
        public Item Item { get; set; }
        
        public int ItemId { get ; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }    /* per item rate*/
        public double Discount { get; set; }    /* discount applied post tax */
        public double Tax { get; set; }
        public double Amount { get; set; }  /*  Q*R*(1+T/100)*(1-D/100)  */
    }
}
