using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.Product
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }


        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int Stock { get; set; }


    }
}
