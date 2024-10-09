using MovieStoreApp.Models;

namespace MovieStore.Contracts
{
    public interface IMovieService
    {
        void AddMovie(Movie movie);
        IList<Movie> GetMovies();
        Movie? GetById(long id);
        void RemoveMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}