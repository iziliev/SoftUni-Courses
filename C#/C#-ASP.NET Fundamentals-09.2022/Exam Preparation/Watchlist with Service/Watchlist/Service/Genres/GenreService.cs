using Watchlist.Data.Common;
using Watchlist.Data.Models;

namespace Watchlist.Service.Genres
{
    public class GenreService : IGenreService
    {
        private readonly IRepository repository;

        public GenreService(IRepository _repository)
        {
            repository = _repository;
        }

        public List<Genre> GetGenres()
        {
            return repository.All<Genre>().ToList();
        }
    }
}
