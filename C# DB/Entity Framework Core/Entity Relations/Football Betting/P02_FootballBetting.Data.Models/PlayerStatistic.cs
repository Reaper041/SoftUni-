using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public Game Game { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        [Required]
        public byte ScoredGoals { get; set; }

        [Required]
        public byte Assists { get; set; }

        [Required]
        public byte MinutesPlayed { get; set; }
    }
}
