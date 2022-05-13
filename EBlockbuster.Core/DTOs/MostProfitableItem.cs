using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.DTOs
{
    public class MostProfitableItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
