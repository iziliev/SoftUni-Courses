using Watchlist.Data.Models;
using Watchlist.Models.Movie;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> GetAllMovies();

        Task<List<Genre>> GetGenres();

        Task CreateMovie(MovieViewFormModel movieModel);

        Task<Movie?> GetMovieById(int id);

        Task AddMovieAsWatched(Movie movie,string userId);

        Task<IEnumerable<MovieViewModel>> GetAllWatchedMovies(string userId);

        Task RemoveMovieFromWatched(Movie movie, string userId);
    }
}
