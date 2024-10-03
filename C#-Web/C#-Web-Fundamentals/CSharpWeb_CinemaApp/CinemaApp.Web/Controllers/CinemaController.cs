using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController(CinemaContext dbContext) : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = await dbContext
                .Cinemas
                .Select(c => new CinemaIndexViewModel
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Location = c.Location,
                })
                .OrderBy(x => x.Location)
                .ToArrayAsync();

            return View(cinemas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            Cinema cinema = new Cinema()
            {
                Name = model.Name,
                Location = model.Location,
            };

            await dbContext.Cinemas.AddAsync(cinema);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public IActionResult Details(string? id)
        {
            Guid cinemaGuid = Guid.Empty;

            bool isIdValid = IsGuidValid(id, ref cinemaGuid);

            Cinema? cinema = dbContext
                .Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .FirstOrDefault(c => c.Id == cinemaGuid);


            if (isIdValid == false || cinema == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CinemaDetailsViewModel viewModel = new CinemaDetailsViewModel()
            {
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = cinema
                .CinemaMovies
                .Where(cm => cm.IsDeleted == false)
                .Select(cm => new ViewModels.Movie.CinemaMovieViewModel()
                {
                    Title = cm.Movie.Title,
                    Duration = cm.Movie.Duration,
                }).ToArray()
            };

            return View(viewModel);
        }
    }
}
