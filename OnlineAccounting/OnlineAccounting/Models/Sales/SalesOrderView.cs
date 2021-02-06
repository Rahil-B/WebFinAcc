using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales
{
    public class SalesOrderView
    {
        public int Id { get; set; }
        
        public Customer customer { get; set; }
        public string SalesOrderNumber { get; set; }
        public DateTime Date { get; set; }
        public double ShippingCharges { get; set; }
        public double ChargeAdjustment { get; set; }
        public double Total { get; set; }
        public int TotalItems { get; set; }
        public IList<ItemDetail> ItemList { get; set; }
    }
}
