using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly CinemaContext cinemaContext;

        public MovieController(CinemaContext cinemaContext)
        {
            this.cinemaContext = cinemaContext;
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Movie> movies = this.cinemaContext
                .Movies
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Create(AddMovieInputModel inputModel)
        {
            bool isDateValid = DateTime.TryParseExact(inputModel.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

            if (!isDateValid)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate), "Invalid release date!");
                return this.View(inputModel);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            Movie movie = new Movie()
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                Director = inputModel.Director,
                Duration = inputModel.Duration,
                ReleaseDate = releaseDate,
                Genre = inputModel.Genre,
            };

            this.cinemaContext.Movies.Add(movie);
            this.cinemaContext.SaveChanges();

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            bool isValidId = Guid.TryParse(id, out var movieId);

            if (!isValidId)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Movie? movie = this.cinemaContext
                .Movies
                .FirstOrDefault(x => x.Id == movieId);

            if (movie == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return View(movie);
        }
    }
}
