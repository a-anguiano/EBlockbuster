using System.ComponentModel.DataAnnotations;

namespace EBlockbuster.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters")]  //good length?
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(50, ErrorMessage = "Phone cannot exceed 50 characters")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Login Id is required")]
        public int LoginId { get; set; }

        [Required(ErrorMessage = "Credit Card Id is required")]
        public int CreditCardId { get; set; }
    }
}
