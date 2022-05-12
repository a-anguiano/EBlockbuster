using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Entities
{
    [Table("Product")]
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        //FK Category

        //Connects to ProductCustomer
        public List<ProductCustomer> ProductCustomers { get; set; }
    }
}
