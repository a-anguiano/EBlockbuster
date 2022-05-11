using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //FK CreditCard
        public int CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
        //FK Login
        public int LoginId { get; set; }
        public Login Login { get; set; }
        //FK SecurityLevel
        public int SecurityLevelId { get; set; }
        public SecurityLevel SecurityLevel { get; set; }
        //Connects to ProductCustomer
        public List<ProductCustomer> ProductCustomers { get; set; }
    }
}
