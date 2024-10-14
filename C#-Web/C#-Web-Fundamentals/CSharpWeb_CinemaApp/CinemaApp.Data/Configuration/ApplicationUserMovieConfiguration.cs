using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class ApplicationUserMovieConfiguration : IEntityTypeConfiguration<ApplicationUserMovie>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMovie> builder)
        {
            builder
                .HasKey(um => new { um.UserGuid, um.MovieGuid });

            builder
                .HasOne(um => um.Movie)
                .WithMany(m => m.MovieUsers)
                .HasForeignKey(m => m.MovieGuid);

            builder
                .HasOne(um => um.ApplicationUser)
                .WithMany(u => u.UserMovies)
                .HasForeignKey(um =>  um.UserGuid);
        }
    }
}
