using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models1
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PositionName { get; set; } = null!;

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
