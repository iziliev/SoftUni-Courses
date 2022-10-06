using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models.Movie;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;
        private readonly IUserService userService;

        public MovieService(WatchlistDbContext _context, 
            IUserService _userService)
        {
            context = _context;
            userService = _userService;
        }

        public async Task AddMovieAsWatched(Movie movie, string userId)
        {
            var user = await userService.GetCurrentUser(userId);
            
            var userMovie = new UserMovie
            {
                UserId = userId,
                MovieId = movie.Id,
                Movie=movie,
                User=user
            };

            var isMoveeAlreadyWatch = await context.UserMovies.Where(u => u.UserId == userId && u.MovieId == movie.Id).FirstOrDefaultAsync();

            if (isMoveeAlreadyWatch == null)
            {
                user.UsersMovies.Add(userMovie);
                await context.SaveChangesAsync();
            }

        }

        public async Task RemoveMovieFromWatched(Movie movie, string userId)
        {
            var user = await userService.GetCurrentUser(userId);

            var userMovie = new UserMovie
            {
                UserId = userId,
                MovieId = movie.Id,
                Movie = movie,
                User = user
            };

            var userWatch = await context.Users
                .Where(u=>u.Id==userId)
                .Include(u=>u.UsersMovies)
                .ThenInclude(um=>um.Movie)
                .ThenInclude(g=>g.Genre)
                .FirstOrDefaultAsync();

            if (userWatch != null)
            {
                var movieData = userWatch.UsersMovies.FirstOrDefault(m => m.MovieId == movie.Id);

                if (movie!= null)
                {
                    userWatch.UsersMovies.Remove(movieData);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task CreateMovie(MovieViewFormModel movieModel)
        {
            var movie = new Movie()
            {
                Title = movieModel.Title,
                Director = movieModel.Director,
                ImageUrl = movieModel.ImageUrl,
                Rating = movieModel.Rating,
                GenreId = movieModel.GenreId,
                Genre = movieModel.Genre
            };

            await context.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllMovies()
        {
            var movies = await context.Movies.Include(g=>g.Genre).ToListAsync();

            return movies.Select(movie => new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                ImageUrl = movie.ImageUrl,
                Rating = movie.Rating,
                GenreId = movie.GenreId,
                Genre = movie.Genre.Name
            });
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllWatchedMovies(string userId)
        {
            var user = await context.Users
                .Where(u=>u.Id == userId)
                .Include(um=>um.UsersMovies)
                .ThenInclude(m=>m.Movie)
                .ThenInclude(g=>g.Genre)
                .FirstOrDefaultAsync();

            return user.UsersMovies
                .Select(m => new MovieViewModel
                {
                    Id = m.Movie.Id,
                    Director = m.Movie.Director,
                    Genre = m.Movie.Genre.Name,
                    GenreId = m.Movie.GenreId,
                    ImageUrl = m.Movie.ImageUrl,
                    Rating = m.Movie.Rating,
                    Title = m.Movie.Title,
                }).ToList();
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            return await context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
