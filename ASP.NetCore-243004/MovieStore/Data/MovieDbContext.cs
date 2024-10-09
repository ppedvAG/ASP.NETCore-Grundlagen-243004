using Microsoft.EntityFrameworkCore;
using MovieStoreApp.Models;

namespace MovieStoreApp.Data
{
    public class MovieDbContext : DbContext
    {
        private readonly IList<Movie> _movies =
        [
            new Movie
            {
                Id = 1,
                Title = "The Shawshank Redemption",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Genre = MovieGenre.Drama,
                Price = 13.99m,
                IMDBRating = 8.5,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg"
            },
            new Movie
            {
                Id = 2,
                Title = "The Godfather",
                Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                Genre = MovieGenre.Drama,
                Price = 19.99m,
                IMDBRating = 7.6,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg"
            },
            new Movie
            {
                Id = 3,
                Title = "Jurassic Park",
                Description = "A pragmatic paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids.",
                Genre = MovieGenre.Adventure,
                Price = 12.99m,
                IMDBRating = 9,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Jurassic_Park_Poster.jpg"
            }
        ];

        public DbSet<Movie> Movies { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasData(_movies);
        }
    }
}
