using System;
using System.Collections.Generic;

namespace Ecommerce.Models
{
   public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime? ExpireDate { get; set; }

        public bool IsActive { get; set; }  

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public List<ProductOrder> Orders { get; set; }

    }
}
