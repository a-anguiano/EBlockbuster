using EBlockbuster.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EBlockbuster.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(250, ErrorMessage = "Description cannot exceed 50 characters")]
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
