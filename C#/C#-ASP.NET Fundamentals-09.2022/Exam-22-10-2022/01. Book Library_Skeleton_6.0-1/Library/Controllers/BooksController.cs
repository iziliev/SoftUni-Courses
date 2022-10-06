using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService _bookService)
        {
            bookService = _bookService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllBooksAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new BookFormViewModel()
            {
                Categories = bookService.GetAllCategory().ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something wrong");
                model.Categories = bookService.GetAllCategory().ToList();
                return View(model);
            }
            
            await bookService.AddBook(model);

            return RedirectToAction("All","Books");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            var username = User.Identity?.Name;

            if (username == null)
            {
                return RedirectToAction("All", "Books");
            }

            if (await bookService.BookExistInCollection(bookId, username))
            {
                return RedirectToAction("All", "Books");
            }

            await bookService.AddBookToUser(bookId, username);

            return RedirectToAction("All", "Books");
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var username = User.Identity?.Name;

            if (username == null)
            {
                throw new ArgumentException();
            }

            var books = await bookService.GetUserBooksAsync(username);

            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var username = User.Identity?.Name;

            if (username == null)
            {
                throw new ArgumentException();
            }

            await bookService.RemoveBookToUser(bookId, username);

            return RedirectToAction("Mine", "Books");
        }
    }
}
