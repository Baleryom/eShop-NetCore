using System.ComponentModel.DataAnnotations;

namespace eShop.Api.DTOs
{
    public class ProductPutPostDTO
    {//validation non null
        [Required]
        [MaxLength(25)]
        [MinLength(10)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        [Range(0,10000000)]
        public double Price { get; set; }
        public string PhotoUrl { get; set; }
    }
}
