using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    [JsonObject]
    public class ImportProductDTO
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Price))]
        public decimal Price { get; set; }

        [JsonProperty(nameof(SellerId))]
        public int SellerId { get; set; }

        [JsonProperty(nameof(BuyerId))]
        public int? BuyerId { get; set; }
    }
}
