using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales
{
    public class Invoice
    {
        public int Id { get; set; }
        // public string userId { get; set; } /*can be ommited*/
        public SalesOrder SalesOrder { get; set; }
        [Required]
        public int SalesOrderId { get; set; }
        public string SalesOrderNumber { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
    }
}
