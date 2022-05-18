using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Entities
{
    public class Prices
    {
        [Key]
        public int PriceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
