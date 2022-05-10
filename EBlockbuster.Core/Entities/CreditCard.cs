using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Entities
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public int Number { get; set; }
        public DateOnly ExpDate { get; set; }   //read as string?
        public int SVC { get; set; }
        //Connects to customer
    }
}
