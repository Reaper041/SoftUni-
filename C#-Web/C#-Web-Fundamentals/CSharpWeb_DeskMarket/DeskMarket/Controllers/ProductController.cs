using DeskMarket.Data;
using DeskMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using DeskMarket.Data.Models;
using static DeskMarket.Common.ValidationConstants;
using System.Security.Claims;

namespace DeskMarket.Controllers
{
    public class ProductController(ApplicationDbContext context) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currUserId = GetCurrentUserId() ?? string.Empty;

            var models = await context
                .Products
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductInfoViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    ProductName = p.ProductName,
                    SellerId = p.SellerId
                })
                .AsNoTracking()
                .ToListAsync();

            foreach (var model in models)
            {
                if (currUserId == model.SellerId)
                {
                    model.IsSeller = true;
                }
                foreach (var productClient in context.ProductsClients)
                {
                    if (productClient.ProductId == model.Id && productClient.ClientId == currUserId)
                    {
                        model.HasBought = true;
                    }
                }
            }

            return View(models);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddProductViewModel
            {
                Categories = await context.Categories.ToListAsync()
            };

            return View(model);
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories  = await context.Categories.ToListAsync();

                return View(model);
            }

            bool parseDate = DateTime.TryParseExact(model.AddedOn, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime addedOn);

            if (!parseDate)
            {
                model.Categories = await context.Categories.ToListAsync();

                ModelState.AddModelError(nameof(model.AddedOn), "Invalid Date");

                return View(model);
            }

            Product entity = new Product
            {
                ProductName = model.ProductName,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                AddedOn = addedOn,
                IsDeleted = false,
                CategoryId = model.CategoryId,
                SellerId = GetCurrentUserId() ?? string.Empty
            };

            await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var currUserId = GetCurrentUserId() ?? string.Empty;

            var models = await context
                .Products
                .Where(p => p.ProductsClients.Any(pc => pc.ClientId == currUserId) && p.IsDeleted == false)
                .Select(p => new ProductInfoViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,

                })
                .AsNoTracking()
                .ToListAsync();

            return View(models);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AddProductViewModel? model = await context
                .Products
                .Where(p => p.IsDeleted == false && p.Id == id)
                .AsNoTracking()
                .Select(p => new AddProductViewModel()
                {
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    AddedOn = p.AddedOn.ToString(DateTimeFormat),
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    SellerId = p.SellerId
                })
                .FirstOrDefaultAsync();

            model!.Categories = await context.Categories.ToListAsync();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(AddProductViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await context.Categories.ToListAsync();

                return View(model);
            }


            bool parseDate = DateTime.TryParseExact(model.AddedOn, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime addedOn);

            if (!parseDate)
            {
                model.Categories = await context.Categories.ToListAsync();

                ModelState.AddModelError(nameof(model.AddedOn), "Invalid Date");

                return View(model);
            }

            Product? entity = await context.Products.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid id");
            }


            entity.ProductName = model.ProductName;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.AddedOn = addedOn;
            entity.IsDeleted = false;
            entity.CategoryId = model.CategoryId;
            entity.SellerId = GetCurrentUserId() ?? string.Empty;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), nameof(Product), new RouteValueDictionary {{ "id", $"{id}" }});
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var currUserId = GetCurrentUserId() ?? string.Empty;

            Product? model = await context
                .Products
                .Where(p => p.Id == id)
                .Include(p => p.ProductsClients)
                .FirstOrDefaultAsync();

            if (model!.ProductsClients.All(pc => pc.ClientId != currUserId))
            {
                ProductClient productClient = new ProductClient()
                {
                    ProductId = id,
                    ClientId = currUserId,
                };

                await context.ProductsClients.AddAsync(productClient);
                await context.SaveChangesAsync();
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var currUserId = GetCurrentUserId() ?? string.Empty;

            ProductClient? entity = await context
                .ProductsClients
                .Where(pc => pc.ProductId == id && pc.ClientId == currUserId)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new ArgumentException("Invalid id");
            }

            context.ProductsClients.Remove(entity);
            await context.SaveChangesAsync();


            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ProductDetailsViewModel? model = await context
                .Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel()
                {
                    Id = id,
                    Seller = p.Seller.UserName ?? string.Empty,
                    ProductName = p.ProductName,
                    AddedOn = p.AddedOn.ToString(DateTimeFormat),
                    CategoryName = p.Category.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                throw new ArgumentException("Invalid id");
            }

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteProductViewModel? model = await context
                .Products
                .Where(p => p.Id == id)
                .Select(p => new DeleteProductViewModel()
                {
                    ProductName = p.ProductName,
                    Id = p.Id,
                    Seller = p.Seller.UserName ?? string.Empty,
                    SellerId = p.SellerId
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteProductViewModel model)
        {
            Product? entity = await context
                .Products
                .Where(p => p.Id == model.Id && p.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            entity.IsDeleted = true;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
