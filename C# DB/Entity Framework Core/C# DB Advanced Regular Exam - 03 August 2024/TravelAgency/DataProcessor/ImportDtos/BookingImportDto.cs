using System.ComponentModel.DataAnnotations;
using TravelAgency.Shared;

namespace TravelAgency.DataProcessor.ImportDtos
{
    public class BookingImportDto
    {
        [Required]
        public string BookingDate { get; set; } = null!;

        [Required]
        [MinLength(Shared.GlobalConstants.CustomerFullNameMinLength)]
        [MaxLength(GlobalConstants.CustomenFullNameMaxLength)]
        public string CustomerName { get; set; } = null!;

        [Required]
        [MinLength(GlobalConstants.PackageNameMinLength)]
        [MaxLength(GlobalConstants.PackageNameMaxLength)]
        public string TourPackageName { get; set; } = null!;
    }
}
