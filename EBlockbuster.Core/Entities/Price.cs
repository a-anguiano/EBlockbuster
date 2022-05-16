using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Entities
{
    public class Price
    {
        public int PriceId { get; set; }
        public decimal RentStandard { get; set; }
        public decimal RentHD { get; set; }
        public decimal BuyStandard { get; set; }
        public decimal BuyHD { get; set; }
    }
}
