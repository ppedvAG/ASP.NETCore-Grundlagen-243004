using BusinessLogic.Contracts;
using BusinessLogic.Data;
using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly FoodDeliveryDbContext _context;

        public RecipeService(FoodDeliveryDbContext context)
        {
            _context = context;
        }

        public List<Recipe> GetAllRecipes()
        {
            return _context.Recipes.ToList();
        }

        public Recipe? GetRecipeById(int id)
        {
            return _context.Recipes.FirstOrDefault(r => r.Id == id);
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);

            _context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _context.Update(recipe);

            _context.SaveChanges();
        }

        public bool DeleteRecipe(int id)
        {
            var recipe = GetRecipeById(id);
            if (recipe == null)
            {
                return false;
            }

            _context.Recipes.Remove(recipe);

            _context.SaveChanges();
            return true;
        }

    }
}
