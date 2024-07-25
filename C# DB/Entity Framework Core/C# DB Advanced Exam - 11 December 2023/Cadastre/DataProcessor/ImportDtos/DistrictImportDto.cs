using Cadastre.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType(nameof(District))]
    public class DistrictImportDto
    {
        [XmlAttribute(nameof(Region))]
        [Required]
        public string Region { get; set; } = null!;

        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(2)]
        [MaxLength(80)]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(PostalCode))]
        [Required]
        [RegularExpression(@"^[A-Z]{2}-\d{5}$")]
        public string PostalCode { get; set; } = null!;

        [XmlArray(nameof(Properties))]
        public PropertyImportDto[] Properties { get; set; } = null!;
    }
}
 