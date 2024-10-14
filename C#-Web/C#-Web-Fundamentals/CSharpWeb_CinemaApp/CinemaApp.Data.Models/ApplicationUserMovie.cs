namespace CinemaApp.Data.Models
{
    public class ApplicationUserMovie
    {
        public Guid UserGuid { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid MovieGuid { get; set; }

        public virtual Movie Movie { get; set; } = null!;
    }
}
