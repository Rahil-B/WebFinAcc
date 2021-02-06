using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.User
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Address Line-1")]
        public string AddressLine1 { get; set; }
        [Required]
        [Display(Name = "Address Line-2")]
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string AddressState { get; set; }
        [MinLength(15, ErrorMessage = "Must be 15 characters")]
        [MaxLength(15, ErrorMessage = "Must be 15 characters")]
        [Display(Name = "GSTIN / PAN")]
        public string GSTIN { get; set; }
    }
}
