using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required] 
        public string SellerId { get; set; } = null!;

        [ForeignKey(nameof(SellerId))] 
        public IdentityUser Seller { get; set; } = null!;

        [Required]
        public DateTime AddedOn { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))] 
        public Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
    }
}
