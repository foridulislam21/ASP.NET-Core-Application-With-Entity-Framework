using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please provide minimum length 4")]
        public string Address { get; set; }

        [Range(0, 1000)]
        public int LoyaltyPoint { get; set; }
    }
}