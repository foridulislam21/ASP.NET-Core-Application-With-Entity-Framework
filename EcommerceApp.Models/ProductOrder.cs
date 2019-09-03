namespace Ecommerce.Models
{
    public class ProductOrder
    {

        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
