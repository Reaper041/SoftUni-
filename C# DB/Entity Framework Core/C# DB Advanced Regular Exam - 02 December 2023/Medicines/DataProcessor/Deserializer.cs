namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<Patient> validPatients = new List<Patient>();

            PatientImportDto[] patientImportDtos = (PatientImportDto[])JsonConvert.DeserializeObject<PatientImportDto[]>(jsonString)!;

            foreach (var patientImportDto in patientImportDtos)
            {
                if (!IsValid(patientImportDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                int patientAgeGroup = int.Parse(patientImportDto.AgeGroup);
                int patientGender = int.Parse(patientImportDto.Gender);

                if (patientAgeGroup < 0 || patientAgeGroup > 2 || patientGender < 0 || patientGender > 1)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var patient = new Patient()
                {
                    FullName = patientImportDto.FullName,
                    AgeGroup = (AgeGroup)Enum.Parse(typeof(AgeGroup), patientImportDto.AgeGroup),
                    Gender = (Gender)Enum.Parse(typeof(Gender), patientImportDto.Gender),
                };

                foreach (var medicineDto in patientImportDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(pm => pm.MedicineId == medicineDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medicineDto
                    };

                    patient.PatientsMedicines.Add(patientMedicine);
                }

                validPatients.Add(patient);
                stringBuilder.AppendLine(String.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));

            }

            context.Patients.AddRange(validPatients);
            context.SaveChanges();
            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ICollection<Pharmacy> validPharmacies = new List<Pharmacy>();

            var xmlSerializer = new XmlSerializer(typeof(PharmacyImportDto[]), new XmlRootAttribute("Pharmacies"));

            using StringReader xmlReader = new StringReader(xmlString);
            var pharmacyImportDtos = (PharmacyImportDto[])xmlSerializer.Deserialize(xmlReader)!;

            foreach (var pharmacyDto in pharmacyImportDtos)
            {
                if (!IsValid(pharmacyDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                if (pharmacyDto.IsNonStop != "true" && pharmacyDto.IsNonStop != "false")
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    Name = pharmacyDto.Name,
                    IsNonStop = bool.Parse(pharmacyDto.IsNonStop),
                    PhoneNumber = pharmacyDto.PhoneNumber,
                };

                foreach (var medicineDto in pharmacyDto.Medicines)
                {
                    if (!IsValid(medicineDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime productionDate = DateTime.ParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime expiryDate = DateTime.ParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);


                    if (DateTime.Compare(productionDate, expiryDate) >= 0)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (pharmacy.Medicines.Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer)) 
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine medicine = new Medicine()
                    {
                        Name = medicineDto.Name,
                        Producer = medicineDto.Producer,
                        Category = (Category)medicineDto.Category,
                        Price = (decimal)medicineDto.Price,
                        ExpiryDate = expiryDate,
                        ProductionDate = productionDate,
                    };

                    pharmacy.Medicines.Add(medicine);
                }

                validPharmacies.Add(pharmacy);
                stringBuilder.AppendLine(String.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
