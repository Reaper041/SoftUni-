using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
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
            bool isDateValid = DateTime.TryParseExact(inputModel.ReleaseDate, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

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
            Guid movieGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref movieGuid);

            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Movie? movie = this.cinemaContext
                .Movies
                .FirstOrDefault(x => x.Id == movieGuid);

            if (movie == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        [HttpGet]
        public IActionResult AddToProgram(string? id)
        {
            Guid movieGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref movieGuid);

            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = cinemaContext
                .Movies
                .FirstOrDefault (x => x.Id == movieGuid);

            if(movie == null)
            {
                return RedirectToAction(nameof (Index));
            }

            AddMovieToCinemaInputModel model = new AddMovieToCinemaInputModel()
            {
                Id = id!,
                Title = movie.Title,
                Cinemas = cinemaContext
                .Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .Select(c => new ViewModels.Cinema.CinemaCheckBoxInputModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    IsSelected = c.CinemaMovies.Any(cm => cm.Movie.Id == movieGuid)
                })
                .ToArray()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToProgram(AddMovieToCinemaInputModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Guid movieGuid = Guid.Empty;
            bool isMovieGuidValid = this.IsGuidValid(model.Id, ref movieGuid);

            if (!isMovieGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Movie? movie = cinemaContext
                .Movies
                .FirstOrDefault(c => c.Id == movieGuid);

            if (movie == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            ICollection<CinemaMovie> entitiesToAdd = new List<CinemaMovie>();

            foreach (var cinemaInputModel in model.Cinemas)
            {
                Guid cinemaGuid = Guid.Empty;
                bool isCinemaGuidValid = this.IsGuidValid(cinemaInputModel.Id, ref cinemaGuid);

                if (!isCinemaGuidValid)
                {
                    this.ModelState.AddModelError(String.Empty, "Invalid Cinema selected!");
                    return View(model);
                }

                Cinema? cinema = cinemaContext
                    .Cinemas
                    .FirstOrDefault(c => c.Id == cinemaGuid);

                if (cinema == null)
                {
                    this.ModelState.AddModelError(String.Empty, "Invalid Cinema selected!");
                    return View(model);
                }
                CinemaMovie? cinemaMovie = cinemaContext.CinemasMovies
                        .FirstOrDefault(cm => cm.MovieId == movieGuid && cm.CinemaId == cinemaGuid);

                if (cinemaInputModel.IsSelected)
                {
                    if (cinemaMovie == null)
                    {
                        entitiesToAdd.Add(new CinemaMovie
                        {
                            Cinema = cinema,
                            Movie = movie,
                        });
                    }
                    else
                    {
                        cinemaMovie.IsDeleted = false;
                    }
                }
                else
                {
                    if (cinemaMovie != null)
                    {
                        cinemaMovie.IsDeleted = true;
                    }
                }

                cinemaContext.SaveChanges();
            }

            cinemaContext.AddRange(entitiesToAdd);
            cinemaContext.SaveChanges();

            return RedirectToAction(nameof(Index), "Cinema");
        }    
    }
}
