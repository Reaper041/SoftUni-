using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models1
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = null!;

        public string? Email { get; set; }

        [Required]
        public decimal Balance { get; set; }


        public ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }
}
