namespace DeskMarket.Models
{
    public class DeleteProductViewModel
    {
        public int Id { get; set; }

        public required string ProductName { get; set; }

        public required string SellerId { get; set; }

        public required string Seller { get; set; }
    }
}
