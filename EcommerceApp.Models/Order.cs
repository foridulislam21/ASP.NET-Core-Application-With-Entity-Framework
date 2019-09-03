using System;
using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }

        public List<ProductOrder> Products { get; set; }
    }
}
