using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task AddBook(BookFormViewModel bookModel)
        {
            var book = new Book()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                CategoryId = bookModel.CategoryId,
                Description = bookModel.Description,
                ImageUrl = bookModel.ImageUrl,
                Rating = bookModel.Rating
            };

            await context.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task AddBookToUser(int bookId, string username)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Book not exist!");
            }

            var user = await context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("User not exist!");
            }

            var au = new ApplicationUserBook()
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                Book = book,
                BookId = bookId
            };

            user.ApplicationUsersBooks.Add(au);
            await context.SaveChangesAsync();
        }

        public async Task<bool> BookExistInCollection(int bookId, string username)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Book not exist!");
            }

            var user = await context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("User not exist!");
            }

            var au = new ApplicationUserBook()
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                Book = book,
                BookId = bookId
            };

            var books = await context.ApplicationUserBooks
                .Where(u => u.ApplicationUserId == user.Id)
                .ToListAsync();

            return books.Contains(au);
        }

        public async Task<ICollection<BookViewModel>> GetAllBooksAsync()
        {
            return await context.Books.Select(x => new BookViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Category = x.Category.Name,
                ImageUrl = x.ImageUrl,
                Rating = x.Rating.ToString()
            }).ToListAsync();
        }

        public ICollection<Category> GetAllCategory()
        {
            return context.Categories.ToList();
        }

        public async Task<ICollection<BookViewModel>> GetUserBooksAsync(string username)
        {
            var user = await context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

            return await context.ApplicationUserBooks
                .Where(u => u.ApplicationUserId == user.Id)
                .Include(x => x.Book)
                .Select(x => new BookViewModel
                {
                    Author = x.Book.Author,
                    Id = x.Book.Id,
                    Category = x.Book.Category.Name,
                    ImageUrl = x.Book.ImageUrl,
                    Rating = x.Book.Rating.ToString(),
                    Title = x.Book.Title,
                }).ToListAsync();
        }

        public async Task RemoveBookToUser(int bookId, string username)
        {
            var book = context.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Book not exist!");
            }

            var user = await context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("User not exist!");
            }

            var au = new ApplicationUserBook()
            {
                ApplicationUser = user,
                ApplicationUserId = user.Id,
                Book = book,
                BookId = bookId
            };

            context.Remove(au);

            await context.SaveChangesAsync();
        }
    }
}
