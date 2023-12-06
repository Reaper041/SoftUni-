using System.ComponentModel.DataAnnotations;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ValidationContext = AutoMapper.ValidationContext;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            ProductShopContext context = new ProductShopContext();

            string inputJson = File.ReadAllText("../../../Datasets/products.json");
            string inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            string inputJsonCat = File.ReadAllText("../../../Datasets/categories.json");
            string inputJsonCatProd = File.ReadAllText("../../../Datasets/categories-products.json");


            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Console.WriteLine(ImportUsers(context, inputJsonUsers));
            //Console.WriteLine(ImportProducts(context, inputJson));
            //Console.WriteLine(ImportCategories(context, inputJsonCat));
            //Console.WriteLine(ImportCategoryProducts(context, inputJsonCatProd));

            var products = context.Products.ToArray();
            string json = GetProductsInRange(context);

            File.WriteAllText("../../../Results", json);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDTO[] userDtos = JsonConvert.DeserializeObject<ImportUserDTO[]>(inputJson);

            ICollection<User> users = new List<User>();

            foreach (ImportUserDTO userDto in userDtos)
            {
                User user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDTO[] productDtos = JsonConvert.DeserializeObject<ImportProductDTO[]>(inputJson);

            ICollection<Product> products = new List<Product>();

            foreach (var productDto in productDtos)
            {
                Product product = Mapper.Map<Product>(productDto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoryDTO[] categoriesDtos = JsonConvert.DeserializeObject<ImportCategoryDTO[]>(inputJson);

            ICollection<Category> categories = new List<Category>();

            foreach (var importCategoryDto in categoriesDtos)
            {
                if (!IsValid(importCategoryDto))
                {
                    continue;
                }

                Category category = Mapper.Map<Category>(importCategoryDto);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDTO[] categoryProductDtos =
                JsonConvert.DeserializeObject<ImportCategoryProductDTO[]>(inputJson);

            ICollection<CategoryProduct> categories = new List<CategoryProduct>();

            foreach (var importCategoryProductDto in categoryProductDtos)
            {
                CategoryProduct categoryProduct = Mapper.Map<CategoryProduct>(importCategoryProductDto);

                categories.Add(categoryProduct);
            }

            context.CategoriesProducts.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";

        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductsInRangeDTO[] products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductsInRangeDTO>()
                .ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult);
            return isValid;
        }
    }
}