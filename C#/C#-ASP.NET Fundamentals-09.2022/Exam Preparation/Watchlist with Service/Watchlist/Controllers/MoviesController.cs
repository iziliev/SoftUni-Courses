using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data.Common;
using Watchlist.Data.Models;
using Watchlist.Models.Movies;
using Watchlist.Service.Genres;
using Watchlist.Service.Movies;

namespace Watchlist.Controllers
{
    public class MoviesController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;

        public MoviesController(UserManager<User> _userManager, 
            IMovieService _movieService,
            IGenreService _genreService)
        {
            userManager = _userManager;
            movieService = _movieService;
            genreService = _genreService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ViewData["Title"] = "Watchlist";

            var movies = await movieService.GetAllMovies();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Title"] = "Add Movie";

            var movieModel = new MovieFormViewModel()
            {
                Genres = genreService.GetGenres()
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

            await movieService.AddMovie(movieModel);

            return RedirectToAction("All","Movies");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var currentMovie = movieService.GetCurrentMovieById(id);

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
                await movieService.AddMoviesToCurrentUser(currentMovie, currentUser);

                return RedirectToAction("All", "Movies");
            }

            ModelState.AddModelError("", "Movie already watched.");

            return RedirectToAction("All", "Movies");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var currentMovie = movieService.GetCurrentMovieById(id);

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

            await movieService.RemoveMoviesFromCurrentUser(currentMovie, currentUser);

            return RedirectToAction("All", "Watched");
        }

        [HttpGet]
        public IActionResult Watched()
        {
            ViewData["Title"] = "Watchlist";

            var currentUser = GetUserMovies();

            var moviesOnUser = movieService.GetWatchedMovies(currentUser);

            return View(moviesOnUser);
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
    }
}
