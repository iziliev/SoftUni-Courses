using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data.Common;
using Watchlist.Data.Models;
using Watchlist.Models.Movies;

namespace Watchlist.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IRepository repository;
        private readonly UserManager<User> userManager;

        public MoviesController(IRepository _repository,
            UserManager<User> _userManager)
        {
            repository = _repository;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "Watchlist";

            var movies = await repository
                .All<Movie>()
                .Select(x => new MovieViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Director = x.Director,
                    ImageUrl = x.ImageUrl,
                    Rating = x.Rating,
                    Genre = x.Genre.Name
                }).ToListAsync();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Title"] = "Add Movie";

            var movieModel = new MovieFormViewModel()
            {
                Genres = GetGenre()
            };

            return View(movieModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieFormViewModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something wrong. Try again.");

                return View(movieModel);
            }

            var movie = new Movie()
            {
                Title = movieModel.Title,
                Director = movieModel.Director,
                Description = movieModel.Description,
                ImageUrl = movieModel.ImageUrl,
                Rating = movieModel.Rating,
                GenreId = movieModel.GenreId,
            };

            await repository.AddAsync(movie);
            await repository.SaveChangesAsync();

            return RedirectToAction("All","Movies");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var currentMovie = GetCurrentMovie(id);

            if (currentMovie == null)
            {
                ModelState.AddModelError("", "Movie doesn't exist.");

                return RedirectToAction("All", "Movies");
            }

            var currentUser = GetUserMovies();

            if (currentUser == null)
            {
                ModelState.AddModelError("", "Somthing wrong.");

                return RedirectToAction("All", "Movies");
            }

            if (!IsMovieIsWatched(currentMovie, currentUser))
            {
                currentUser.WatchedMovies.Add(currentMovie);

                await repository.SaveChangesAsync();

                return RedirectToAction("All", "Movies");
            }

            ModelState.AddModelError("", "Movie already watched.");

            return RedirectToAction("All", "Movies");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var currentMovie = GetCurrentMovie(id);

            if (currentMovie == null)
            {
                ModelState.AddModelError("", "Movie doesn't exist.");

                return RedirectToAction("All", "Movies");
            }

            var currentUser = GetUserMovies();

            if (currentUser == null)
            {
                ModelState.AddModelError("", "Somthing wrong.");

                return RedirectToAction("All", "Movies");
            }

            currentUser.WatchedMovies.Remove(currentMovie);

            await repository.SaveChangesAsync();

            return RedirectToAction("All", "Movies");
        }

        [HttpGet]
        public IActionResult Watched()
        {
            ViewData["Title"] = "Watchlist";

            var currentUser = GetUserMovies();

            var moviesOnUser = currentUser.WatchedMovies
                .Select(x => new MovieViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Director = x.Director,
                    ImageUrl = x.ImageUrl,
                    Rating = x.Rating,
                    Genre = repository.All<Genre>().FirstOrDefault(g=>g.Id == x.GenreId).Name
                }).ToList();

            return View(moviesOnUser);
        }


        private Movie GetCurrentMovie(int id)
        {
            return repository
                .All<Movie>()
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }

        private bool IsMovieIsWatched(Movie currentMovie, User currentUser)
        {
            return currentUser.WatchedMovies
                .Where(x => x.Id == currentMovie.Id)
                .FirstOrDefault() == null ? false : true;
        }

        private User GetUserMovies()
        {
            return userManager.Users
                .Include(m => m.WatchedMovies)
                .FirstOrDefault(u => u.UserName == GetCurrentUsername());
        }

        private string GetCurrentUsername()
        {
            return User.Identity.Name;
        }

        private List<Genre> GetGenre()
        {
            return repository.All<Genre>().ToList();
        }

    }
}
