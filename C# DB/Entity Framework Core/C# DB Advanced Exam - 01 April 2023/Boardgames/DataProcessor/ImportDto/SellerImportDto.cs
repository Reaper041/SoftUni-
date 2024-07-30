using Boardgames.Shared;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto
{
    public class SellerImportDto
    {
        [Required]
        [MinLength(GlobalConstants.SellerNameMinLength)]
        [MaxLength(GlobalConstants.SellerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(GlobalConstants.SellerAddressMinLength)]
        [MaxLength(GlobalConstants.SellerAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(GlobalConstants.SellerWebsiteRegex)]
        public string Website { get; set; } = null!;

        public int[] Boardgames { get; set; } = null!;
    }
}
