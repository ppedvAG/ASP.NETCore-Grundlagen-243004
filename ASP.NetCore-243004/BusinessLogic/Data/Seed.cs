using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data
{
    internal class Seed
    {
        internal readonly static Seed Instance = new();

        private Seed() 
        { 
        }

        internal void SeedData(ModelBuilder builder)
        {
            var items = RecipeReader.FromJsonFile("Data\\RecipeData.json");

            builder.Entity<Recipe>().HasData(items);
        }
    }
}
