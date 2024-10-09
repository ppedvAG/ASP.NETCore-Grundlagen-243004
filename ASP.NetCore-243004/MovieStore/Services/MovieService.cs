using MovieStoreApp.Data;
using MovieStore.Contracts;
using MovieStoreApp.Models;

namespace MovieStoreApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        public IList<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie? GetById(long id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id); 
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void RemoveMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
