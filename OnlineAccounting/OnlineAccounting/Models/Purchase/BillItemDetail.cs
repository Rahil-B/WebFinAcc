using OnlineAccounting.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase
{
    public class BillItemDetail
    {
        public int Id { get; set; }
        public Customer customer { get; set; }
        public int CustomerID { get; set; }
        public Bill bill { get; set; }
        public int BillId { get; set; }
        public Item item { get; set; }
        public int ItemId { get; set; }
        public FinancialAccount Account { get; set; }
        public int AccountId { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public double Tax { get; set; }
        public double Amount { get; set; }
        public void setAmount()
        {
            Amount = (Rate * Quantity) * (100 + Tax) / 100;
        }
    }
    
}
