using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineAccounting.Models.Purchase
{
    public class Vendor
    {
        public int Id { get; set; }
        public string userId { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        public string Name { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Company Name cannot exceed 30 characters")]
        public string CompanyName { get; set; }
        /*
        [Required, MaxLength(8, ErrorMessage = "HSN Code cannot exceed 8 characters")]
        public string HSNCode { get; set; }*/
        /*[Required]
        public Boolean IsIndividual { get; set; }*/ /* Individual OR organization */
        [Required]
        public string SourceOfSupply { get; set; }
        [Required, MaxLength(15, ErrorMessage = "GSTIN/PAN/UIN Code cannot exceed 15 characters")]
        public string GSTIN { get; set; } /* GSTIN OR  */
        public int FinancialAccountId { get; set; }
    }
}
