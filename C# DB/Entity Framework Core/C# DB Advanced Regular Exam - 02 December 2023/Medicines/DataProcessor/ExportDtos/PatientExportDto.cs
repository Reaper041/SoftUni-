using Medicines.Data.Models;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType(nameof(Patient))]
    public class PatientExportDto
    {
        [XmlElement(nameof(Name))]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(AgeGroup))]
        public string AgeGroup { get; set; } = null!;

        public MedicineXMLExportDto[] Medicines { get; set; } = null!;

        [XmlAttribute(nameof(Gender))]
        public string Gender { get; set; } = null!;
    }
}
