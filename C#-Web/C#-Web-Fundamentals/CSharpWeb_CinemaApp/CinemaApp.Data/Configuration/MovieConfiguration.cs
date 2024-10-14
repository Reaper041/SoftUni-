using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CinemaApp.Common.EntityValidationConstants.Movie;
using static CinemaApp.Common.ApplicationConstants;

namespace CinemaApp.Data.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder
                .Property(x => x.Genre)
                .IsRequired()
                .HasMaxLength(GenreMaxLength);

            builder
                .Property(x => x.Director)
                .IsRequired()
                .HasMaxLength(DirectorMaxLength);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder.Property(m => m.ImageUrl)
                .IsRequired(false)
                .HasDefaultValue(NoImgUrl);

            builder.HasData(SeedMovies());
        }

        private List<Movie> SeedMovies()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie()
                {
                    Title = "Harry Potter",
                    Genre = "Fantasy",
                    Director = "Mike Newel",
                    ReleaseDate = new DateTime(2005, 11, 8),
                    Duration = 157,
                    Description = "Some description"
                },
                new Movie()
                {
                    Title = "Lord Of The Rings",
                    Genre = "Fantasy",
                    ReleaseDate = new DateTime(2001, 05, 7),
                    Director = "Peter Jackson",
                    Duration = 278,
                    Description = "Some description"
                }
            };

            return movies;
        }
    }
}
