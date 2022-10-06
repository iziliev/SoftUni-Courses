using Library.Contracts;
using Library.Data.Common;
using Library.Models.Book;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Library.Data.DataConstants;

namespace Library.Controllers
{
    public class BooksController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IRepository repository;

        public BooksController(IBookService _bookService,
            IRepository _repository)
        {
            bookService = _bookService;
            repository = _repository;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await bookService.GetAllBooks();

            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var bookModel = new BookViewModel()
            {

                Categories = bookService.GetAllCategory()
            };
            return View(bookModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookViewModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                bookModel.Categories = bookService.GetAllCategory();
                ModelState.AddModelError("",Error.ViewModelError);
                return View(bookModel);
            }

            await bookService.AddBook(bookModel);

            return RedirectToAction("All", "Books");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await bookService.AddBookToUserCollection(bookId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Readed()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await bookService.GetReadBooks(userId);

            return View("Mine", model);
        }

        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await bookService.RemoveBookFromCurrentUser(bookId, userId);

            return RedirectToAction(nameof(Readed));
        }
    }
}
