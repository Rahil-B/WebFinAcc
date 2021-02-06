using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models
{
    public class FinancialAccountType
    {
        public int Id { get; set; }

        public string userId { get; set; }

        [Required]
        public PrimaryAccountType Type { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
