using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CinemaApp.Web.Controllers
{
    [Authorize]
    public class WatchlistController(CinemaContext dbContext, UserManager<ApplicationUser> userManager) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userGuid = userManager.GetUserId(User)!;

            IEnumerable<ApplicationUserWatchlistViewModel> watchlist = await dbContext
                .UsersMovies
                .Include(um => um.Movie)
                .Where(um => um.UserGuid.ToString().ToLower().Equals(userGuid.ToLower()))
                .Select(um => new ApplicationUserWatchlistViewModel()
                {
                    MovieGuid = um.MovieGuid.ToString(),
                    Title = um.Movie.Title,
                    Genre = um.Movie.Genre,
                    ReleaseDate = um.Movie.ReleaseDate.ToString("MM/yyyy"),
                    ImageUrl = um.Movie.ImageUrl
                })
                .ToListAsync();
                

            return View(watchlist);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist(string? movieId)
        {
            Guid movieGuid = Guid.Empty;

            if (!IsGuidValid(movieId, ref movieGuid))
            {
                return RedirectToAction("Index", "Movie");
            }

            Movie? movie = await dbContext.Movies
                .FirstOrDefaultAsync(m => m.Id == movieGuid);

            if (movie == null)
            {
                return RedirectToAction("Index", "Movie");
            }

            Guid userGuid = Guid.Parse(userManager.GetUserId(User)!);
            bool addedToWatchlist = await dbContext
                .UsersMovies
                .AnyAsync(um => um.UserGuid == userGuid && 
                                um.MovieGuid == movieGuid);

            if (!addedToWatchlist)
            {
                ApplicationUserMovie newUserMovie = new ApplicationUserMovie()
                {
                    UserGuid = userGuid,
                    MovieGuid = movieGuid,
                };

                await dbContext.UsersMovies.AddAsync(newUserMovie);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromWatchlist(string? movieId)
        {
            Guid movieGuid = Guid.Empty;

            if (!IsGuidValid(movieId, ref movieGuid))
            {
                return RedirectToAction("Index", "Movie");
            }

            Movie? movie = await dbContext.Movies
                .FirstOrDefaultAsync(m => m.Id == movieGuid);

            if (movie == null)
            {
                return RedirectToAction("Index", "Movie");
            }

            Guid userGuid = Guid.Parse(userManager.GetUserId(User)!);
            ApplicationUserMovie? applicationUserMovie = await dbContext
                .UsersMovies
                .FirstOrDefaultAsync(um => um.UserGuid == userGuid &&
                                um.MovieGuid == movieGuid);

            if (applicationUserMovie != null)
            {
                dbContext.UsersMovies.Remove(applicationUserMovie);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
