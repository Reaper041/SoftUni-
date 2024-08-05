using System.ComponentModel.DataAnnotations;
using TravelAgency.Shared;

namespace TravelAgency.Data.Models
{
    public class TourPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PackageNameMaxLength)]
        public string PackageName { get; set; } = null!;

        [MaxLength(GlobalConstants.TourPackageDescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new List<TourPackageGuide>();
    }
}
