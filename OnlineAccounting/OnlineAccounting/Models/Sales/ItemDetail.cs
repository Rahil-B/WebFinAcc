using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales
{
    public class ItemDetail
    {
        public int Id { get; set; }
        public SalesOrder salesOrder { get; set; }
        public int SalesOrderId { get; set; }
        [Required]
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }    /* per item rate*/
        public double Discount { get; set; }    /* discount applied post tax */
        public double Tax { get; set; }
        public double Amount { get; set; }  /*  Q*R*(1+T/100)*(1-D/100)  */
    }
}
