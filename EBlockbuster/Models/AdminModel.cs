using System.ComponentModel.DataAnnotations;

namespace EBlockbuster.Models
{
    public class AdminModel
    {
        public int AdminId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Login Id is required")]
        public int LoginId { get; set; }
    }
}
