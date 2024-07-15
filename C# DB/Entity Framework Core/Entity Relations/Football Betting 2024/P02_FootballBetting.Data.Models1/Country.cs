using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models1
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;


        public ICollection<Town> Towns { get; set; } = new List<Town>();
    }
}
