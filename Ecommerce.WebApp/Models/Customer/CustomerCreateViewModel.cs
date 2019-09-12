using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApp.Models.Customer
{
    public class CustomerCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please provide minimum length 4")]
        public string Address { get; set; }

        [Range(0, 1000)]
        public int LoyaltyPoint { get; set; }

        [NotMapped]
        public List<Ecommerce.Models.Customer> CustomerList { get; set; }
    }
}