using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext context;

        public GameController(GameZoneDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var models = await this.context
                .Games
                .Select(e => new GameInfoViewModel()
                {
                    Genre = e.Genre.Name,
                    Id = e.Id,
                    Publisher = e.Publisher.UserName ?? string.Empty,
                    ImageUrl = e.ImageUrl,
                    ReleasedOn = e.ReleasedOn.ToString("yyyy-MM-dd"),
                    Title = e.Title,
                })
                .AsNoTracking()
                .ToListAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddGameViewModel();
            model.Genres = await context.Genres.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await context.Genres.ToListAsync();

                return View(model);
            }

            DateTime releasedOn;

            bool parseDate = DateTime.TryParseExact(model.ReleasedOn, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releasedOn);

            if (!parseDate)
            {
                model.Genres = await context.Genres.ToListAsync();

                ModelState.AddModelError(nameof(model.ReleasedOn), "Invalid Date");

                return View(model);
            }

            Game game = new Game()
            {
                Description = model.Description,
                GenreId = model.GenreId,
                Title = model.Title,
                PublisherId = GetCurrentUserId() ?? string.Empty, 
                ImageUrl = model.ImageUrl,
                ReleasedOn = releasedOn,
            };

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AddGameViewModel? model = await this.context
                .Games
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(m => new AddGameViewModel()
                {
                    Title = m.Title,
                    Description = m.Description,
                    GenreId = m.GenreId,
                    ImageUrl = m.ImageUrl,
                    ReleasedOn = m.ReleasedOn.ToString("yyyy-MM-dd")
                })
                .FirstOrDefaultAsync();

            model!.Genres = await context.Genres.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddGameViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await context.Genres.ToListAsync();

                return View(model);
            }

            DateTime releasedOn;

            bool parseDate = DateTime.TryParseExact(model.ReleasedOn, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releasedOn);

            if (!parseDate)
            {
                model.Genres = await context.Genres.ToListAsync();

                ModelState.AddModelError(nameof(model.ReleasedOn), "Invalid Date");

                return View(model);
            }

            Game? entity = await this.context.Games.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid id");
            }

            entity.Description = model.Description;
            entity.GenreId = model.GenreId;
            entity.Title = model.Title;
            entity.PublisherId = GetCurrentUserId() ?? string.Empty;
            entity.ImageUrl = model.ImageUrl;
            entity.ReleasedOn = releasedOn;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            var currUserId = GetCurrentUserId() ?? string.Empty;

            var models = await this.context
                .Games
                .Where(g => g.GamersGames.Any(gr => gr.GamerId == currUserId))
                .Select(g => new GameInfoViewModel()
                {
                    Id = g.Id,
                    ReleasedOn = g.ReleasedOn.ToString("yyyy-MM-dd"),
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    Title = g.Title,
                    Publisher = g.Publisher.UserName ?? string.Empty
                })
                .AsNoTracking()
                .ToListAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            var currUserId = GetCurrentUserId() ?? string.Empty;

            Game? model = await this.context
                .Games
                .Where(g => g.Id == id)
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync();

            if (!model!.GamersGames.Any(gr => gr.GamerId == currUserId))
            {
                GamerGame gamerGame = new GamerGame()
                {
                    GameId = id,
                    GamerId = currUserId,
                };

                await this.context.GamersGames.AddAsync(gamerGame);
                await this.context.SaveChangesAsync();
            }
            else
            {
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            var currUserId = GetCurrentUserId() ?? string.Empty;

            GamerGame? entity = await this.context
                .GamersGames
                .Where(gr => gr.GameId == id && gr.GamerId == currUserId)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new ArgumentException("Invalid id");
            }

            this.context.GamersGames.Remove(entity);
            await this.context.SaveChangesAsync();


            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            GameInfoViewModel? model = await this.context
                .Games
                .Where(g => g.Id == id)
                .Select(g => new GameInfoViewModel()
                {
                    Title = g.Title,
                    Genre = g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString("yyyy-MM-dd"),
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    Id = id
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                throw new ArgumentException("Invalid id");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteGameViewModel? model = await this.context
                .Games
                .Where (g => g.Id == id)
                .Select(g => new DeleteGameViewModel()
                {
                    Id = id,
                    Title = g.Title,
                    Publisher = g.Publisher.UserName ?? string.Empty,
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteGameViewModel model)
        {
            Game? entity = await this.context
                .Games
                .Where(g => g.Id == model.Id)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            this.context.Games.Remove(entity);
            await this.context.SaveChangesAsync();

            return RedirectToAction(nameof(All)); 
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
