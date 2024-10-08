using BusinessLogic.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DemoMvcApp.Models
{
    public class CreateRecipeViewModel
    {
        [Required(ErrorMessage = "Rezeptname muss angegeben werden")]
        public string Name { get; set; }

        public IFormFile? Image { get; set; }

        public string? Ingredients { get; set; }

        public string? Instructions { get; set; }

        public float Rating { get; set; }

        public int PrepTimeMinutes { get; set; }

        public int CookTimeMinutes { get; set; }

        public Difficulty Difficulty { get; set; }

        public Cuisine Cuisine { get; set; }

        public MealType MealType { get; set; }

        public string? Tags { get; set; }

        public int CaloriesPerServing { get; set; }
    }
}
