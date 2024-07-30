using Boardgames.Data.Models;
using Boardgames.Shared;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType(nameof(Creator))]
    public class CreatorImportDto
    {
        [XmlElement(nameof(FirstName))]
        [Required]
        [MinLength(GlobalConstants.CreatorNameMinLength)]
        [MaxLength(GlobalConstants.CreatorNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [XmlElement(nameof(LastName))]
        [Required]
        [MinLength(GlobalConstants.CreatorNameMinLength)]
        [MaxLength(GlobalConstants.CreatorNameMaxLength)]
        public string LastName { get; set; } = null!;

        [XmlArray(nameof(Boardgames))]
        public BoardgameImportDto[] Boardgames { get; set; } = null!;
    }
}
