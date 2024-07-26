using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.Utilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            var properties = dbContext.Properties.AsNoTracking()
                .Where(p => p.DateOfAcquisition >= new DateTime(2000, 1, 1))
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new PropertyExportDto()
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.PropertiesCitizens
                    .Select(pc => pc.Citizen)
                    .OrderBy(c => c.LastName)
                    .Select(c => new CitizenExportDto()
                    {
                        LastName = c.LastName,
                        MaritalStatus = c.MaritalStatus.ToString(),
                    })
                    .ToArray()
                })
                .ToList();

            return JsonConvert.SerializeObject(properties, Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            StringBuilder stringBuilder = new StringBuilder();
            XMLHelper xmlHelper = new XMLHelper();

            var properties = dbContext.Properties.AsNoTracking()
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new XMLPropertyExportDto()
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    PostalCode = p.District.PostalCode,
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XMLPropertyExportDto[]), new XmlRootAttribute("Properties"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(stringBuilder);
            xmlSerializer.Serialize(writer, properties, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
