namespace CinemaApp.Web.ViewModels.Watchlist
{
    public class ApplicationUserWatchlistViewModel
    {
        public string MovieGuid { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string ReleaseDate { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
