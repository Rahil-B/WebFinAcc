
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action:"IsEmailValid", controller: "Account")]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
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
        [MinLength(15,ErrorMessage ="Must be 15 characters")]
        [MaxLength(15, ErrorMessage = "Must be 15 characters")]
        [Display(Name = "GSTIN / PAN")]
        public string GSTIN { get; set; }
    }
}
