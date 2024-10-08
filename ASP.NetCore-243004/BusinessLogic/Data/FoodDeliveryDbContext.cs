using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data
{
    public class FoodDeliveryDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public FoodDeliveryDbContext(DbContextOptions<FoodDeliveryDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Seed.Instance.SeedData(modelBuilder);
        }
    }
}
