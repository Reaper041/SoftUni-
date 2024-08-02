using Medicines.Data.Models;
using Medicines.GlobalConstants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType(nameof(Pharmacy))]
    public class PharmacyImportDto
    {
        [XmlAttribute("non-stop")]
        [Required]
        public string IsNonStop { get; set; } = null!;

        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(GlobalConstants.GlobalConstants.PharmacyNameMinLength)]
        [MaxLength(GlobalConstants.GlobalConstants.PharmacyNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(PhoneNumber))]
        [Required]
        [RegularExpression(GlobalConstants.GlobalConstants.PharmacyPhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray(nameof(Medicines))]
        public MedicineImportDto[] Medicines { get; set; } = null!;
    }
}
