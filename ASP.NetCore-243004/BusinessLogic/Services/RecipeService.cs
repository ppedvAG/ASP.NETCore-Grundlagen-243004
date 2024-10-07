using BusinessLogic.Contracts;
using BusinessLogic.Data;
using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public class RecipeService : IRecipeService
    {
        static List<Recipe> recipes = RecipeReader.FromJsonFile("Data\\RecipeData.json") ?? new List<Recipe>();

        public List<Recipe> GetAllRecipes()
        {
            return recipes;
        }

        public Recipe GetRecipeById(int id)
        {
            return recipes.FirstOrDefault(r => r.Id == id);
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Insert(0, recipe);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            var index = recipes.FindIndex(r => r.Id == recipe.Id);
            recipes[index] = recipe;
        }

        public bool DeleteRecipe(int id)
        {
            var index = recipes.FindIndex(r => r.Id == id);
            if (index >= 0)
            {
                recipes.RemoveAt(index);
                return true;
            }
            return false;
        }

    }
}
