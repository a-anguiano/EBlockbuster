using System.ComponentModel.DataAnnotations;

namespace EBlockbuster.Models
{
    public class LoginModel
    {
        public int LoginId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, ErrorMessage = "Password cannot exceed 15 characters")]
        public string Password { get; set; }

        public int SecurityLevelId { get; set; }
    }
}
