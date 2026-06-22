using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.Product
{
    public class ProductPatchDto
    {
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal? Price { get; set; }

        [Range(0, int.MaxValue)]
        public int? Stock { get; set; }

        public bool? IsActive { get; set; }

    }
}
