using Microsoft.AspNetCore.Mvc;
using OnlineAccounting.Models.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase
{
    public class Expense
    {
        public int Id { get; set; }
        public string userId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Description { get; set; }

        [Required]
        public ExpenseType Type { get; set; } /* goods OR service , ..*/
        [Required]
        public double Amount { get; set; }
        public FinancialAccount ExpenseAccount { get; set; }
        public int ExpenseAccountId { get; set; }

        public FinancialAccount PaidFromAccount { get; set; }
        public int PaidFromAccountId { get; set; }
        [Required]
        [MaxLength(12,ErrorMessage ="Must be atmost 15 digits")]
        [Display(Name ="HSN / SAC Code")]
        public string HSNCode { get; set; } /*HSN or SAC*/
        public Vendor Vendor { get; set; }
        [Required]
        public int VendorId { get; set; }
        [Required]
        public double Tax { get; set; }
        public string InvoiceReferance { get; set; }

        public JournalEntry JournalEntry { get; set; }

        public int JournalEntryId { get; set; }
    }
}