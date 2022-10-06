using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Contracts;
using Watchlist.Data.Models;
using Watchlist.Models.Movie;

using static Watchlist.Data.DataConstants.Error;

namespace Watchlist.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        { 
            var movies = await movieService.GetAllMovies();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var movieModel = new MovieViewFormModel()
            {
                Genres = movieService.GetGenres().Result
            };

            ViewData["Title"] = "Add Movie";

            return View(movieModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MovieViewFormModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", ModelStateError);

                movieModel = new MovieViewFormModel()
                {
                    Genres = movieService.GetGenres().Result
                };
                return View(movieModel);
            }

            await movieService.CreateMovie(movieModel);

            return RedirectToAction(nameof(MovieController.All),
                            Utilities.ControllerName<MovieController>());
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var currentMovie = await movieService.GetMovieById(movieId);

            if (currentMovie == null)
            {
                ModelState.AddModelError("", ModelStateError);

                return RedirectToAction(nameof(MovieController.All),
                            Utilities.ControllerName<MovieController>());
            }

            var user = GetCurrentUserId();

            if (user == null)
            {
                ModelState.AddModelError("", ModelStateError);

                return RedirectToAction(nameof(MovieController.All),
                            Utilities.ControllerName<MovieController>());
            }

            await movieService.AddMovieAsWatched(currentMovie, user);

            return RedirectToAction(nameof(MovieController.All),
                            Utilities.ControllerName<MovieController>());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var currentMovie = await movieService.GetMovieById(movieId);

            if (currentMovie == null)
            {
                ModelState.AddModelError("", ModelStateError);

                return RedirectToAction(nameof(MovieController.Watched),
                            Utilities.ControllerName<MovieController>());
            }

            var user = GetCurrentUserId();

            if (user == null)
            {
                ModelState.AddModelError("", ModelStateError);

                return RedirectToAction(nameof(MovieController.Watched),
                            Utilities.ControllerName<MovieController>());
            }

            await movieService.RemoveMovieFromWatched(currentMovie, user);

            return RedirectToAction(nameof(MovieController.Watched),
                            Utilities.ControllerName<MovieController>());
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            var user = GetCurrentUserId();

            ViewData["Title"] = "Watched Movies";

            var movies = await movieService.GetAllWatchedMovies(user);

            return View("Mine",movies);
        }

        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
