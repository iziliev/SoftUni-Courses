using System.Collections.Generic;
using Watchlist.Data.Models;
using Watchlist.Models.Movies;

namespace Watchlist.Service.Movies
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> GetAllMovies();

        Task AddMovie(MovieFormViewModel movieModel);

        Task AddMoviesToCurrentUser(Movie movie,User user);

        Task RemoveMoviesFromCurrentUser(Movie movie, User user);

        IEnumerable<MovieViewModel> GetWatchedMovies(User user);

        Movie GetCurrentMovieById(int id);
    }
}
