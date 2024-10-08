using BusinessLogic.Models;

namespace BusinessLogic.Contracts
{
    public interface IRecipeService
    {
        void AddRecipe(Recipe recipe);
        bool DeleteRecipe(int id);
        List<Recipe> GetAllRecipes();
        Recipe? GetRecipeById(int id);
        void UpdateRecipe(Recipe recipe);
    }
}