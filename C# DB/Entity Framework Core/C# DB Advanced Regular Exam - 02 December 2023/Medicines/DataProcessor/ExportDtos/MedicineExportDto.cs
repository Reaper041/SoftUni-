namespace Medicines.DataProcessor.ExportDtos
{
    public class MedicineExportDto
    {
        public string Name { get; set; } = null!;

        public string Price { get; set; } = null!;

        public PharmacyExportDto Pharmacy { get; set; } = null!;
    }
}
