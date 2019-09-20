using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.WebApp.Models.Product
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provide A Product Name")]
        [MaxLength(10)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public DateTime? ExpireDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [NotMapped]
        public List<Ecommerce.Models.Product> ProductList { get; set; }

        public List<ProductOrder> Orders { get; set; }
    }
}