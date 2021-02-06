using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales
{
    public class PaymentReceived
    {
        public int Id { get; set; }
        public string userId { get; set; }/**/
        public int CustomerId { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        public string CustomerName { get; set; }
        public double Amount { get; set; }
        public double BankCharges { get; set; }
        public string ReferanceNumber { get; set; }
        public FinancialAccount DepositedToAccount { get; set; }
        public int DepositedToAccountId { get; set; }
    }
}
