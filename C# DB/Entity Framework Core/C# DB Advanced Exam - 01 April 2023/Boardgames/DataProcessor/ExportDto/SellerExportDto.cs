namespace Boardgames.DataProcessor.ExportDto
{
    public class SellerExportDto
    {
        public string Name { get; set; } = null!;

        public string Website { get; set; } = null!;

        public BoardgameExportDto[] Boardgames { get; set; } = null!;
    }
}
