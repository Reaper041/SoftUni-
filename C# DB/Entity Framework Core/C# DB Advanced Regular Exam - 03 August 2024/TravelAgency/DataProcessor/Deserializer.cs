using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ICollection<Customer> validCustomers = new List<Customer>();

            var xmlSerializer = new XmlSerializer(typeof(CustomerImportDto[]), new XmlRootAttribute("Customers"));

            using StringReader xmlReader = new StringReader(xmlString);
            var customerImportDtos = (CustomerImportDto[])xmlSerializer.Deserialize(xmlReader)!;

            foreach ( CustomerImportDto customerDto in customerImportDtos )
            {
                if (!IsValid(customerDto))
                {
                    stringBuilder.AppendLine(ErrorMessage); 
                    continue; 
                }

                var customer = new Customer
                {
                    FullName = customerDto.FullName,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.PhoneNumber,
                };

                if (validCustomers.Any(vc => vc.FullName == customerDto.FullName 
                || vc.Email == customerDto.Email 
                || vc.PhoneNumber == customerDto.PhoneNumber))
                {
                    stringBuilder.AppendLine(DuplicationDataMessage);
                    continue;
                }

                validCustomers.Add(customer);
                stringBuilder.AppendLine(String.Format(SuccessfullyImportedCustomer, customer.FullName));
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ICollection<Booking> validBookings = new List<Booking>();

            BookingImportDto[] bookingImportDtos = JsonConvert.DeserializeObject<BookingImportDto[]>(jsonString)!;

            foreach (var bookingDto in bookingImportDtos)
            {
                if (!IsValid(bookingDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidDate = DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime bookingDate);

                if (!isValidDate)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Booking booking = new Booking()
                {
                    BookingDate = bookingDate,
                    CustomerId = context.Customers.Where(c => c.FullName == bookingDto.CustomerName).Select(c => c.Id).FirstOrDefault(),
                    TourPackageId = context.TourPackages.Where(tp => tp.PackageName == bookingDto.TourPackageName).Select(tp => tp.Id).FirstOrDefault(),
                };

                validBookings.Add(booking);
                stringBuilder.AppendLine(String.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, bookingDate.ToString("yyyy-MM-dd")));
            }

            context.Bookings.AddRange(validBookings);
            context.SaveChanges(); 
            return stringBuilder.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
