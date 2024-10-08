using BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Test
{
    public class TestDatabase
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=UnitTestDemo;Trusted_Connection=True;ConnectRetryCount=0";
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        private FoodDeliveryDbContext _context;

        public FoodDeliveryDbContext Context => _context ??= CreateContext();

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

        private FoodDeliveryDbContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<FoodDeliveryDbContext>().UseSqlServer(ConnectionString);
            var context = new FoodDeliveryDbContext(builder.Options);
            return context;
        }
    }
}