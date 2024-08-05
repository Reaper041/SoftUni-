using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TravelAgency.Data.Models;
using TravelAgency.Shared;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType(nameof(Customer))]
    public class CustomerImportDto
    {
        [XmlElement(nameof(FullName))]
        [Required]
        [MinLength(Shared.GlobalConstants.CustomerFullNameMinLength)]
        [MaxLength(GlobalConstants.CustomenFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [XmlElement(nameof(Email))]
        [Required]
        [MinLength(GlobalConstants.CustomerEmailMinLength)]
        [MaxLength(GlobalConstants.CustomerEmailMaxLength)]
        public string Email { get; set; } = null!;

        [XmlAttribute("phoneNumber")]
        [Required]
        [RegularExpression(GlobalConstants.CustomerPhoneRegEx)]
        public string PhoneNumber { get; set; } = null!;
    }
}
