using Medicines.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType(nameof(Medicine))]
    public class MedicineImportDto
    {
        [XmlAttribute("category")]
        [Range(0, 4)]
        public int Category { get; set; }

        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(GlobalConstants.GlobalConstants.MedicineNameMinLength)]
        [MaxLength(GlobalConstants.GlobalConstants.MedicineNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(Price))]
        [Required]
        [Range(GlobalConstants.GlobalConstants.MedicinePriceMinValue, GlobalConstants.GlobalConstants.MedicinePriceMaxValue)]
        public double Price { get; set; }

        [XmlElement(nameof(ProductionDate))]
        [Required]
        public string ProductionDate { get; set; } = null!;

        [XmlElement(nameof(ExpiryDate))]
        [Required]
        public string ExpiryDate { get; set; } = null!;

        [XmlElement(nameof(Producer))]
        [Required]
        [MinLength(GlobalConstants.GlobalConstants.MedicineProducerMinLength)]
        [MaxLength(GlobalConstants.GlobalConstants.MedicineProducenMaxLength)]
        public string Producer { get; set; } = null!;
    }
}
