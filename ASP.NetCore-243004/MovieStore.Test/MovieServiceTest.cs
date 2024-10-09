using MovieStoreApp.Data;
using MovieStoreApp.Models;
using MovieStoreApp.Services;

namespace MovieStore.Test
{
    [TestClass]
    public class MovieServiceTest
    {
        private readonly TestDatabase _db = new TestDatabase();
        private MovieDbContext _context;
        private MovieService _movieService;

        [TestInitialize]
        public void Initialize()
        {
            _context = _db.Context;
            _movieService = new MovieService(_context);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await _context.DisposeAsync();
        }

        [TestMethod]
        public void GetMovies_ReturnsAllMovies()
        {
            // Arrange
            var expectedCount = _context.Movies.Count() + 2;
            _context.Movies.AddRange(
                new Movie { Title = "Movie 1" },
                new Movie { Title = "Movie 2" }
            );
            _context.SaveChanges();

            // Act
            var result = _movieService.GetMovies();

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
            Assert.IsTrue(result.Any(m => m.Title == "Movie 1"));
            Assert.IsTrue(result.Any(m => m.Title == "Movie 2"));
        }

        [TestMethod]
        public void GetById_ExistingId_ReturnsMovie()
        {
            // Arrange
            var movie = new Movie { Title = "Test Movie" };
            _context.Movies.Add(movie);
            _context.SaveChanges();

            // Act
            var result = _movieService.GetById(movie.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Movie", result.Title);
        }

        [TestMethod]
        public void GetById_NonExistingId_ReturnsNull()
        {
            // Act
            var result = _movieService.GetById(-1);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddMovie_AddsMovieToDatabase()
        {
            // Arrange
            var newMovie = new Movie { Title = "New Movie" };

            // Act
            _movieService.AddMovie(newMovie);

            // Assert
            var addedMovie = _context.Movies.FirstOrDefault(m => m.Title == "New Movie");
            Assert.IsNotNull(addedMovie);
            Assert.AreNotEqual(0, addedMovie.Id);
        }

        [TestMethod]
        public void UpdateMovie_UpdatesMovieInDatabase()
        {
            // Arrange
            var movie = new Movie { Title = "Original Title" };
            _context.Movies.Add(movie);
            _context.SaveChanges();

            // Act
            movie.Title = "Updated Title";
            _movieService.UpdateMovie(movie);

            // Assert
            var updatedMovie = _context.Movies.Find(movie.Id);
            Assert.IsNotNull(updatedMovie);
            Assert.AreEqual("Updated Title", updatedMovie.Title);
        }

        [TestMethod]
        public void RemoveMovie_RemovesMovieFromDatabase()
        {
            // Arrange
            var movie = new Movie { Title = "Movie to Remove" };
            _context.Movies.Add(movie);
            _context.SaveChanges();

            // Act
            _movieService.RemoveMovie(movie);

            // Assert
            var removedMovie = _context.Movies.Find(movie.Id);
            Assert.IsNull(removedMovie);
        }
    }
}