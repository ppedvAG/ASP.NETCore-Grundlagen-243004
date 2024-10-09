using BusinessLogic.Models;

namespace BusinessLogic.Contracts
{
    public interface IRecipeService
    {
        Task AddRecipe(Recipe recipe);
        Task<bool> DeleteRecipe(int id);
        Task<List<Recipe>> GetAllRecipes();
        Task<Recipe?> GetRecipeById(int id);
        Task UpdateRecipe(Recipe recipe);
    }
}