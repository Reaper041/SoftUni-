using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string userText = File.ReadAllText("../../../Datasets/users.json");
            string productText = File.ReadAllText("../../../Datasets/products.json");
            string categoriesText = File.ReadAllText("../../../Datasets/categories.json");
            string categoriesProductsText = File.ReadAllText("../../../Datasets/categories-products.json");

            //Console.WriteLine(ImportUsers(context, userText));
            //Console.WriteLine(ImportProducts(context, productText));
            //Console.WriteLine(ImportCategories(context,categoriesText));
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsText));

            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            //Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);


            context.Users.AddRangeAsync(users);
            context.SaveChanges();


            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRangeAsync(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";

        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson, settings);

            categories.RemoveAll(c => c.Name == null);
            context.Categories.AddRangeAsync(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRangeAsync(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new {
                    FullName = $"{p.Seller.FirstName} {p.Seller.LastName}",
                    p.Name,
                    p.Price
                })
                .ToList();

            return JsonConvert.SerializeObject(products, Formatting.Indented);

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsBought.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,    
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                })
                .ToList();

            var options = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                //NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
                
               return JsonConvert.SerializeObject (users, options);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Include(c => c.CategoriesProducts)
                .ThenInclude(cp => cp.Product)
                .OrderBy(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    Name = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("f2"),
                    TotalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("f2")
                })
                .OrderByDescending(x => x.ProductsCount)
                .ToList();

            var options = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                //NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(categories, options);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null && p.Price != null))
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = u.ProductsSold
                    .Where(p => p.BuyerId != null)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                    .ToArray()
                })
                .ToList();

            var options = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var output = new
            {
                UsersCount = users.Count,
                Users = users.Select(u => new
                {
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.SoldProducts.Length,
                        Products = u.SoldProducts
                    }
                })
            };

            return JsonConvert.SerializeObject(output, options);
        }
    }
}