using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CinemaApp.Common.EntityValidationConstants.Cinema;

namespace CinemaApp.Data.Configuration
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(LocationMaxLength);

            builder.HasData(SeedCinemas());
        }

        private ICollection<Cinema> SeedCinemas()
        {
            ICollection<Cinema> cinemas = new List<Cinema>()
            {
                new Cinema()
                {
                    Name = "Latona",
                    Location = "Svishtov"
                },
                new Cinema()
                {
                    Name = "CineGrand",
                    Location = "Ring Mall Sofia"
                }
            };

            return cinemas;
        }
    }
}
