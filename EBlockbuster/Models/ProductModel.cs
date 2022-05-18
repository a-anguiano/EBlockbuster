using EBlockbuster.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EBlockbuster.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Photo URL is required")]
        [StringLength(125, ErrorMessage = "Photo URL cannot exceed 125 characters")]
        public string Photo { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        public int CategoryId { get; set; }
    }
}
