using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetGoldenBooks(db));

            string asd = "13.43m";

            decimal ass = decimal.Parse(asd);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction;

            bool parseSuccess = Enum.TryParse<AgeRestriction>(command, true, out ageRestriction);

            if (!parseSuccess)
            {
                return String.Empty;
            }

            List<string> books = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookTitles = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        }
    }
}
