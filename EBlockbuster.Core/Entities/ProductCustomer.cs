using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Entities
{
    public class ProductCustomer
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }

        //FK product and customer as well as primary key
    }
}
