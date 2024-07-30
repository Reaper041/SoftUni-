using Boardgames.Data.Models;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType(nameof(Creator))]
    public class CreatorExportDto
    {
        [XmlElement(nameof(CreatorName))]
        public string CreatorName { get; set; } = null!;

        [XmlArray(nameof(Boardgames))]
        public BoardgameXMLExportDto[] Boardgames { get; set; } = null!;

        [XmlAttribute(nameof(BoardgamesCount))]
        public int BoardgamesCount { get; set; }
    }
}
