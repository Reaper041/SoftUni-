namespace Cadastre.DataProcessor.ExportDtos
{
    public class PropertyExportDto
    {
        public string PropertyIdentifier { get; set; } = null!;

        public int Area { get; set; }

        public string Address { get; set; } = null!;

        public string DateOfAcquisition { get; set; } = null!;

        public CitizenExportDto[] Owners { get; set; } = null!;
    }
}
