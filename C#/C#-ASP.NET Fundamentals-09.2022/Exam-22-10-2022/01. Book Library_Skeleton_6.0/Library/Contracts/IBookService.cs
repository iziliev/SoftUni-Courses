using Library.Data.Models;
using Library.Models.Book;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBook(BookViewModel bookModel);

        Task<IEnumerable<BookViewModel>> GetAllBooks();

        List<Category> GetAllCategory();

        Task AddBookToUserCollection(int bookId, string userId);

        Task<Book> GetCurrentBookById(int id);

        Task<IEnumerable<BookViewModel>> GetReadBooks(string userId);

        Task RemoveBookFromCurrentUser(int bookId, string userId);

        Task<Category> GetCategoryById(int categoryId);
    }
}
