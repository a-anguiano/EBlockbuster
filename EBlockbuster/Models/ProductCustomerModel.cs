using EBlockbuster.Core.Entities;

namespace EBlockbuster.Models
{
    public class ProductCustomerModel
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int PriceId { get; set; }
        public decimal Price { get; set; }
    }
}
