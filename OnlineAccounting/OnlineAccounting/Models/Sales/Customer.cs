using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineAccounting.Models.Sales
{
    public class Customer
    {
        public int Id { get; set; }
        public string userId { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required, MaxLength(30, ErrorMessage = "Company Name cannot exceed 30 characters")]
        public string CompanyName { get; set; }
        [Required]
        public CustomerType Type { get; set; } /* Individual , Organization ,... */
        [Required]
        [Display(Name ="Place of Supply")]
        [DataType(DataType.MultilineText)]
        public string PlaceOfSupply { get; set; }
        [Display(Name = "City of Supply")]
        [DataType(DataType.Text)]
        public string CityOfSupply { get; set; }
        [Required, MaxLength(15, ErrorMessage = "GSTIN/PAN/UIN Code cannot exceed 15 characters")]
        public string GSTIN { get; set; }   /* GSTIN OR  */
    }
}
