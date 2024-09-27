using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CinemaApp.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext()
        {
            
        }

        public CinemaContext(DbContextOptions options)
            :base(options) 
        {
            
        }

        public DbSet<Movie> Movies { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
