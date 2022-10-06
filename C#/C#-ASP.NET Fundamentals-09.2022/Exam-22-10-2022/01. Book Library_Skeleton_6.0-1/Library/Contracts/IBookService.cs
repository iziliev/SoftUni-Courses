using Library.Data.Models;
using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<ICollection<BookViewModel>> GetAllBooksAsync();

        ICollection<Category> GetAllCategory();

        Task AddBook(BookFormViewModel bookModel);

        Task AddBookToUser(int bookId, string username);

        Task<ICollection<BookViewModel>> GetUserBooksAsync(string username);

        Task RemoveBookToUser(int bookId, string username);

        Task<bool> BookExistInCollection(int bookId, string username);
    }
}
