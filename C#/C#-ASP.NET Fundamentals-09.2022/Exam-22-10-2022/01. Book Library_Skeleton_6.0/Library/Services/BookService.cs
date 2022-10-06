using Library.Contracts;
using Library.Data.Common;
using Library.Data.Models;
using Library.Models.Book;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository repository;

        public BookService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task AddBook(BookViewModel bookModel)
        {
            var book = new Book()
            {
                Author = bookModel.Author,
                CategoryId = bookModel.CategoryId,
                Description = bookModel.Description,
                ImageUrl = bookModel.ImageUrl,
                Rating = bookModel.Rating,
                Title = bookModel.Title,
                Category = GetCategoryById(bookModel.CategoryId).Result
            };

            await repository.AddAsync(book);
            await repository.SaveChangesAsync();
        }

        public async Task AddBookToUserCollection(int bookId, string userId)
        {
            var user = await repository.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.Books)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book = await repository.All<Book>().FirstOrDefaultAsync(u => u.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Invalid Book ID");
            }

            if (!user.Books.Any(m => m.BookId == bookId))
            {
                user.Books.Add(new ApplicationUserBook()
                {
                    BookId = book.Id,
                    ApplicationUserId = user.Id,
                    Book = book,
                    ApplicationUser = user
                });

                await repository.SaveChangesAsync();
            }

        }

        
        public async Task<IEnumerable<BookViewModel>> GetAllBooks()
        {
            return await repository.All<Book>()
                .Select(b => new BookViewModel
                {
                    Author = b.Author,
                    CategoryId = b.CategoryId,
                    Description = b.Description,
                    Id = b.Id,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Title = b.Title,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public List<Category> GetAllCategory()
        {
            return repository.All<Category>().ToList();
        }

        public async Task<Book> GetCurrentBookById(int id)
        {
            return await repository.GetByIdAsync<Book>(id);
        }

        public async Task<IEnumerable<BookViewModel>> GetReadBooks(string userId)
        {
            var user = await repository.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.Books)
                .ThenInclude(um => um.Book)
                .ThenInclude(m => m.Category)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.Books
                .Select(m => new BookViewModel()
                {
                    Author = m.Book.Author,
                    Category=m.Book.Category.Name,
                    CategoryId = m.Book.CategoryId,
                    Description = m.Book.Description,
                    Id = m.Book.Id,
                    ImageUrl = m.Book.ImageUrl,
                    Rating = m.Book.Rating,
                    Title = m.Book.Title
                });
        }

       

        public async Task RemoveBookFromCurrentUser(int bookId, string userId)
        {
            var user = await repository.All<ApplicationUser>()
                 .Where(u => u.Id == userId)
                 .Include(u => u.Books)
                 .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book = user.Books.FirstOrDefault(m => m.BookId == bookId);

            if (book != null)
            {
                user.Books.Remove(book);

                await repository.SaveChangesAsync();
            }
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await repository.GetByIdAsync<Category>(categoryId);
        }

    }
}
