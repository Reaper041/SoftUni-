namespace TravelAgency.DataProcessor.ExportDtos
{
    public class CustomerExportDto
    {
        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public BookingExportDto[] Bookings { get; set; } = null!;
    }
}
