using GameZone.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class AddGameViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ReleasedOn { get; set; } = DateTime.Today.ToString("yyyy-MM-dd");

        public string? ImageUrl { get; set; }

        [Required]
        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
