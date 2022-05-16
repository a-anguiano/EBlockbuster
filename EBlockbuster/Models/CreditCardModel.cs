using EBlockbuster.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace EBlockbuster.Models
{
    public class CreditCardModel
    {
        public int CreditCardId { get; set; }

        [Required(ErrorMessage = "Credit Card Number is required")]
        [StringLength(50, ErrorMessage = "Credit Card Number cannot exceed 50 characters")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Expiration Date is required")]
        [FutureDate]
        public DateTime ExpDate { get; set; }   //read as string?

        [Required(ErrorMessage = "SVC is required")]
        [StringLength(3, ErrorMessage = "SVC cannot exceed 3 characters")]
        public string SVC { get; set; }

        [Required(ErrorMessage = "Billing Address is required")]
        [StringLength(125, ErrorMessage = "First name cannot exceed 125 characters")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State cannot exceed 50 characters")]  //really should have been 2
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        public int Zipcode { get; set; }
    }
}
