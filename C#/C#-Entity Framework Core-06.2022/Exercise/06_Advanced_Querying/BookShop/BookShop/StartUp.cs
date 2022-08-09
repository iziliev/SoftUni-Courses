namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //Problem 02. Age Restriction
                //var command = Console.ReadLine();
                //Console.WriteLine(GetBooksByAgeRestriction(db,command));

                //Problem 03. Golden Books
                //Console.WriteLine(GetGoldenBooks(db));

                //Problem 04. Books by Price
                //Console.WriteLine(GetBooksByPrice(db));

                //Problem 05. Not Released In
                //var year = int.Parse(Console.ReadLine());
                //Console.WriteLine(GetBooksNotReleasedIn(db,year));

                //Problem 06. Book Titles by Category
                //var category = Console.ReadLine();
                //Console.WriteLine(GetBooksByCategory(db,category));

                //Problem 07. Released Before Date
                //var date = Console.ReadLine();
                //Console.WriteLine(GetBooksReleasedBefore(db,date));

                //Problem 08. Author Search
                //var str = Console.ReadLine();
                //Console.WriteLine(GetAuthorNamesEndingIn(db, str));

                ////Problem 09. Book Search
                var str = Console.ReadLine().ToLower();
                Console.WriteLine(GetBookTitlesContaining(db, str));

                //Problem 10. Book Search by Author
                //var str = Console.ReadLine().ToLower();
                //Console.WriteLine(GetBooksByAuthor(db, str));

                //Problem 11. Count Books
                //var symbolLenght = int.Parse(Console.ReadLine());
                //Console.WriteLine(CountBooks(db, symbolLenght));

                //Problem 12. Total Book Copies
                //Console.WriteLine(CountCopiesByAuthor(db));

                //Problem 13. Profit by Category
                //Console.WriteLine(GetTotalProfitByCategory(db));

                //Problem 14. Most Recent Books
                //Console.WriteLine(GetMostRecentBooks(db));

                //Problem 15. Increase Prices
                //IncreasePrices(db);

                //Problem 16. Remove Books
                //Console.WriteLine(RemoveBooks(db));
            }
        }


        //Problem 02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var booksByAgeRestriction = context.Books
                .Where(e => e.AgeRestriction == ageRestriction)
                .Select(e => new
                {
                    BookName = e.Title
                })
                .OrderBy(b => b.BookName)
                .ToArray();

            foreach (var book in booksByAgeRestriction)
            {
                sb.AppendLine(book.BookName);
            }

            return sb.ToString().Trim();
        }

        //Problem 03. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var goldenBooks = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    BookName = b.Title
                })
                .ToArray();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.BookName);
            }

            return sb.ToString().Trim();
        }

        //Problem 04. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var booksByPrice = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price
                })
                .OrderByDescending(b => b.BookPrice)
                .ToArray();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.BookTitle} - ${book.BookPrice:F2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 05. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var booksNotRealisedIn = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    BookTitle = b.Title
                })
                .ToArray();

            foreach (var book in booksNotRealisedIn)
            {
                sb.AppendLine(book.BookTitle);
            }

            return sb.ToString().Trim();
        }

        //Problem 06. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var listCategory = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var sb = new StringBuilder();

            var booksByCategory = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => listCategory.Contains(bc.Category.Name.ToLower())))
                .Select(b => new
                {
                    BookTitle = b.Title
                })
                .OrderBy(b => b.BookTitle)
                .ToArray();

            foreach (var book in booksByCategory)
            {
                sb.AppendLine(book.BookTitle);
            }

            return sb.ToString().Trim();
        }

        //Problem 07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var dateValue = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksBeforeDate = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate < dateValue)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookEdition = b.EditionType.ToString(),
                    BookPrice = b.Price
                })
                .ToArray();

            foreach (var book in booksBeforeDate)
            {
                sb.AppendLine($"{book.BookTitle} - {book.BookEdition} - ${book.BookPrice:F2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 08. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    AuthorFullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(x=>x.AuthorFullName)
                .ToArray();

            foreach (var autor in authors)
            {
                sb.AppendLine(autor.AuthorFullName);
            }

            return sb.ToString().Trim();
        }

        //Problem 09. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var bookTitlesByStr = context.Books
                .Where(b => b.Title.Contains(input,StringComparison.OrdinalIgnoreCase))
                .Select(b => new
                {
                    Title = b.Title,
                })
                .OrderBy(b => b.Title)
                .ToArray();

            foreach (var title in bookTitlesByStr)
            {
                sb.AppendLine(title.Title);
            }

            return sb.ToString().Trim();
        }

        //Problem 10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var booksByAutor = context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.LastName.StartsWith(input,StringComparison.OrdinalIgnoreCase))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    AutorFirstName = b.Author.FirstName,
                    AutorLastName = b.Author.LastName
                })
                .ToArray();

            foreach (var book in booksByAutor)
            {
                sb.AppendLine($"{book.BookTitle} ({book.AutorFirstName} {book.AutorLastName})");
            }

            return sb.ToString().Trim();
        }

        //Problem 11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(b => b.Title.Length > lengthCheck);
        }

        //Problem 12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var autors = context.Authors
                .Select(b => new
                {
                    Autor = b.FirstName + " " + b.LastName,
                    Copies = b.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(b => b.Copies)
                .ToArray();

            foreach (var autor in autors)
            {
                sb.AppendLine($"{autor.Autor} - {autor.Copies}");
            }

            return sb.ToString().Trim();
        }

        //Problem 13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categoryByBooks = context.Categories
                .Select(c => new
                {
                    Name = c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(b => b.Profit)
                .ThenBy(b => b.Name)
                .ToArray();

            foreach (var category in categoryByBooks)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:F2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var recentBooks = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks.Select(b => new
                    {
                        BookName = b.Book.Title,
                        Date = b.Book.ReleaseDate
                    })
                    .OrderByDescending(b => b.Date)
                    .Take(3)
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            foreach (var category in recentBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookName} ({book.Date.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        //Problem 15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //Problem 16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var bookForDelete = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(bookForDelete);
            context.SaveChanges();

            return bookForDelete.Count();
        }
    }
}
