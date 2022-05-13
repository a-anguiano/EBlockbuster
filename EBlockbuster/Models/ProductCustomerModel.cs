using EBlockbuster.Core.Entities;

namespace EBlockbuster.Models
{
    public class ProductCustomerModel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
