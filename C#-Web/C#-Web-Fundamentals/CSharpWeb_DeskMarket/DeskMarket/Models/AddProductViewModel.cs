using System.ComponentModel.DataAnnotations;
using DeskMarket.Data.Models;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Models
{
    public class AddProductViewModel
    {
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string ProductName { get; set; } = string.Empty;

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        public string AddedOn { get; set; } = DateTime.Today.ToString(DateTimeFormat);

        [Required]
        public int CategoryId { get; set; }

        public string SellerId { get; set; } = string.Empty;

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
