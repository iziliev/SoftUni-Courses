using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Watchlist.Data.Common;
using Watchlist.Data.Models;
using Watchlist.Models.Movies;

namespace Watchlist.Service.Movies
{

    public class MovieService : IMovieService
    {
        private readonly IRepository repository;

        public MovieService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddMovie(MovieFormViewModel movieModel)
        {
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
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllMovies()
        {
            return await repository
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
        }

        public async Task AddMoviesToCurrentUser(Movie movie, User user)
        {
            user.WatchedMovies.Add(movie);
            await repository.SaveChangesAsync();
        }

        public async Task RemoveMoviesFromCurrentUser(Movie movie, User user)
        {
            user.WatchedMovies.Remove(movie);

            await repository.SaveChangesAsync();
        }

        public IEnumerable<MovieViewModel> GetWatchedMovies(User user)
        {
            return user.WatchedMovies
                .Select(x => new MovieViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Director = x.Director,
                    ImageUrl = x.ImageUrl,
                    Rating = x.Rating,
                    Genre = repository.All<Genre>().FirstOrDefault(g => g.Id == x.GenreId).Name
                }).ToList();
        }

        public Movie GetCurrentMovieById(int id)
        {
            return repository
                .All<Movie>()
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}
