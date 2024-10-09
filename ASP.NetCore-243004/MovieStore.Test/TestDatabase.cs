using MovieStoreApp.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieStore.Test
{
    public class TestDatabase
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=UnitTestDemo;Trusted_Connection=True;ConnectRetryCount=0";
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        private MovieDbContext _context;

        public MovieDbContext Context => _context ??= CreateContext();

        public TestDatabase()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using var context = CreateContext();

                    // Sicherstellen, dass Testausgangszustand immer identisch ist
                    context.Database.EnsureDeleted();

                    // Datenbank erzeugen
                    //context.Database.EnsureCreated();

                    // Datenbank erzeugen und Daten migrieren
                    context.Database.Migrate();

                    _databaseInitialized = true;
                }
            }
        }

        private MovieDbContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<MovieDbContext>().UseSqlServer(ConnectionString);
            var context = new MovieDbContext(builder.Options);
            return context;
        }
    }
}