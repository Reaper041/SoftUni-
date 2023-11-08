using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
            
        }

        public FootballBettingContext(DbContextOptions options)
        : base(options)
        {
            
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(e =>
            {
                e.HasKey(ps => new { ps.GameId, ps.PlayerId });
            });

            modelBuilder
                .Entity<Team>(e =>
                {
                    e.HasOne(t => t.PrimaryKitColor)
                        .WithMany(c => c.PrimaryKitTeams)
                        .HasForeignKey(t => t.PrimaryKitColorId)
                        .OnDelete(DeleteBehavior.NoAction);

                    e.HasOne(t => t.SecondaryKitColor)
                        .WithMany(c => c.SecondaryKitTeams)
                        .HasForeignKey(t => t.SecondaryKitColorId)
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder
                .Entity<Game>(g =>
                {
                    g.HasOne(gg => gg.HomeTeam)
                        .WithMany(t => t.HomeGames)
                        .HasForeignKey(gg => gg.HomeTeamId)
                        .OnDelete(DeleteBehavior.NoAction);

                    g.HasOne(gg => gg.AwayTeam)
                        .WithMany(t => t.AwayGames)
                        .HasForeignKey(gg => gg.AwayTeamId)
                        .OnDelete(DeleteBehavior.NoAction);
                });
        }
    }
}
