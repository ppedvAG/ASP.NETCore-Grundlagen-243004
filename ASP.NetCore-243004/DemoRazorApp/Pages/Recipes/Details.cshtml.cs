using BusinessLogic.Contracts;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorApp.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly IRecipeService _recipeService;

        public Recipe Data { get; set; }

        public DetailsModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task OnGet(int id)
        {
            Data = await _recipeService.GetRecipeById(id);
        }
    }
}
