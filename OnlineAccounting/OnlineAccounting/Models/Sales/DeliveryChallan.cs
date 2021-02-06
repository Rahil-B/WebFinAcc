using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales
{
    public class DeliveryChallan
    {
        public int Id { get; set; }
        public string userId { get; set; }
        
        public Customer customer { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public ChallanType Type { get; set; }
        public double  SubTotal { get; set; }
        public double Adjustment { get; set; }
        public double Total { get; set; }
    }
}
