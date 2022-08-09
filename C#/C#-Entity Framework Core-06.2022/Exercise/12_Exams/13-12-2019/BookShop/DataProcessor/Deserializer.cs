namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using static BookShop.Data.XmlHelper;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var booksDto = XmlConverter.Deserializer<ImportBookDto>(xmlString, "Books");

            var books = new List<Book>();

            foreach (var bookDto in booksDto)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var genre = Enum.Parse(typeof(Genre), bookDto.Genre.ToString());

                DateTime date;
                var isDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var b = new Book
                {
                    Name = bookDto.Name,
                    Genre = (Genre)genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = date
                };

                books.Add(b);
                sb.AppendLine(string.Format(SuccessfullyImportedBook, b.Name, b.Price));
            }
            context.AddRange(books);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authorsDto = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            var authors = new List<Author>();

            foreach (var authorDto in authorsDto)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isEmailExist = context.Authors.FirstOrDefault(a => a.Email == authorDto.Email);

                if (isEmailExist != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var a = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email
                };

                foreach (var bookDto in authorDto.Books)
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookDto.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    a.AuthorsBooks.Add(new AuthorBook
                    {
                        Book = book,
                        Author = a
                    });
                }

                if (a.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Add(a);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, $"{a.FirstName} {a.LastName}", a.AuthorsBooks.Count));
            }

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}