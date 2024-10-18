using System.ComponentModel.DataAnnotations;

namespace GameZone.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

        public ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}