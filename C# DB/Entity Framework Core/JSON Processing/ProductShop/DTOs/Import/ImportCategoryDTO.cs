using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    [JsonObject]
    public class ImportCategoryDTO
    {
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }
    }
}
