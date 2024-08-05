using System.ComponentModel.DataAnnotations;
using TravelAgency.Shared;

namespace TravelAgency.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CustomenFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.CustomerEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(13)]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
