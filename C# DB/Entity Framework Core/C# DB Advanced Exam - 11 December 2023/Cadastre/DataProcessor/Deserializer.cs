namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Utilities;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder sb = new StringBuilder();
            XMLHelper xmlHelper = new XMLHelper();

            DistrictImportDto[] dtos = xmlHelper.Deserialize<DistrictImportDto[]>(xmlDocument, "Districts");
            ICollection<District> validDistricts = new List<District>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Districts.Any(d => d.Name == dto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District district = new District()
                {
                    Name = dto.Name,
                    PostalCode = dto.PostalCode,
                    Region = (Region)Enum.Parse(typeof(Region), dto.Region)

                };

                foreach (var propDto in dto.Properties)
                {
                    if (!IsValid(propDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime acquisitionDate = DateTime
                        .ParseExact(propDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (dbContext.Properties.Any(p => p.PropertyIdentifier == propDto.PropertyIdentifier) || 
                        district.Properties.Any(dp => dp.PropertyIdentifier == propDto.PropertyIdentifier))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (dbContext.Properties.Any(p => p.Address == propDto.Address) || 
                        district.Properties.Any(dp => dp.Address == propDto.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Property property = new Property()
                    {
                        PropertyIdentifier = propDto.PropertyIdentifier,
                        Area = propDto.Area,
                        Details = propDto.Details,
                        Address = propDto.Address,
                        DateOfAcquisition = acquisitionDate
                    };

                    district.Properties.Add(property);
                }

                validDistricts.Add(district);
                sb.AppendLine(String.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }

            dbContext.Districts.AddRange(validDistricts);
            dbContext.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
