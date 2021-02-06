using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string userId { get; set; }
        [Required, MaxLength(10, ErrorMessage = "Name cannot exceed 10 characters")]
        public string Name { get; set; }
        [Required, MaxLength(8, ErrorMessage = "HSN Code cannot exceed 8 characters")]
        public string HSNCode { get; set; }
        [Required]
        public Boolean IsTaxable { get; set; }
        [Required]
        public Double SellingPrice { get; set; }
        [Required]
        public Double CostPrice { get; set; }
        [Required]
        public Double DefaultTaxRate { get; set; }
        public FinancialAccount Account { get; set; }
        [Display(Name = "Account")]
        [Required]
        public int AccountId { get; set; }
    }
}
