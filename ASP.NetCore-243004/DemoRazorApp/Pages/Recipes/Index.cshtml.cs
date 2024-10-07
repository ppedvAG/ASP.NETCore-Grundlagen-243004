using BusinessLogic.Contracts;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorApp.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly IRecipeService _recipeService;

        public IEnumerable<Recipe> Recipes { get; set; }

        public IndexModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public void OnGet()
        {
            Recipes = _recipeService.GetAllRecipes();
        }
    }
}
