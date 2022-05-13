using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Entities
{
    [Table("CreditCard")]
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public string Number { get; set; }  //long
        public DateTime ExpDate { get; set; }   //read as string?
        public string SVC { get; set; }
        public string BillingAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        //Connects to customer, determine relationship
        public List<Customer> Customers { get; set; }
    }
}
