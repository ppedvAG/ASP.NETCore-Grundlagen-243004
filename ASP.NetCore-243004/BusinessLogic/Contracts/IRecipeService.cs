using BusinessLogic.Models;

namespace BusinessLogic.Contracts
{
    public interface IRecipeService
    {
        Task AddRecipe(Recipe recipe);
        Task<bool> DeleteRecipe(int id);
        Task<PaginatedList<Recipe>> GetAllRecipes(int pageIndex, int pageSize = 20);
        Task<Recipe?> GetRecipeById(int id);
        Task UpdateRecipe(Recipe recipe);
    }
}