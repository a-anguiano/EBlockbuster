using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Entities
{
    [Table("Customer")]
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //FK CreditCard
        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
        //FK Login
        public int LoginId { get; set; }
        public Login Login { get; set; }

        //Connects to ProductCustomer
        public List<ProductCustomer> ProductCustomers { get; set; }
    }
}
