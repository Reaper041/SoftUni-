namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Utilities;
    using Newtonsoft.Json;
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
            StringBuilder sb = new StringBuilder();

            CitizenImportDto[] dtos = JsonConvert.DeserializeObject<CitizenImportDto[]> (jsonDocument)!;
            List<Citizen> validCitizens = new List<Citizen>();

            foreach (CitizenImportDto dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                if (dto.MaritalStatus != "Unmarried" && 
                    dto.MaritalStatus != "Married" && 
                    dto.MaritalStatus != "Divorced" && 
                    dto.MaritalStatus != "Widowed")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime birthDate = DateTime.ParseExact(dto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);


                Citizen citizen = new Citizen()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    BirthDate = birthDate,
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), dto.MaritalStatus)
                };

                foreach (int prop in dto.Properties)
                {
                    PropertyCitizen propertyCitizen = new PropertyCitizen()
                    {
                        Citizen = citizen,
                        PropertyId = prop,
                    };

                    citizen.PropertiesCitizens.Add(propertyCitizen);
                }

                validCitizens.Add(citizen);
                sb.AppendLine(String.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count));
            }

            dbContext.Citizens.AddRange(validCitizens);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
