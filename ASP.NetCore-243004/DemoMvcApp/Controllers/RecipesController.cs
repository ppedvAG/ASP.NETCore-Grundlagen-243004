﻿using BusinessLogic.Contracts;
using BusinessLogic.Models;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly IPhotoService _photoService;

        public RecipesController(ILogger<RecipesController> logger, IRecipeService recipeService, IPhotoService photoService)
        {
            _recipeService = recipeService;
            _photoService = photoService;
        }

        // GET: RecipeController
        public ActionResult Index()
        {
            var recipes = _recipeService.GetAllRecipes();
            return View(recipes.Take(9));
        }

        // GET: RecipeController/Details/5
        public ActionResult Details(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            return View(recipe ?? new Recipe());
        }

        // GET: RecipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRecipeViewModel model)
        {
            try
            {
                string imageUrl = await UploadImage(model.Image);

                if (ModelState.IsValid)
                {
                    var recipe = new Recipe
                    {
                        Name = model.Name,
                        ImageUrl = imageUrl,
                        Rating = model.Rating,
                        PrepTimeMinutes = model.PrepTimeMinutes,
                        CookTimeMinutes = model.CookTimeMinutes,
                        CaloriesPerServing = model.CaloriesPerServing,
                        Difficulty = model.Difficulty,
                        Cuisine = $"{model.Cuisine}",
                        MealType = [$"{model.MealType}"],
                        Instructions = model.Instructions?.Split(Environment.NewLine) ?? [],
                        Ingredients = model.Ingredients?.Split(Environment.NewLine) ?? [],
                        Tags = model.Tags?.Split(Environment.NewLine) ?? []
                    };
                    _recipeService.AddRecipe(recipe);

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        private async Task<string> UploadImage(IFormFile? file)
        {
            if (file != null)
            {
                using var stream = file.OpenReadStream();
                try
                {
                    return await _photoService.UploadFile(file.FileName, stream);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Image", ex.Message);
                }
            }
            return string.Empty;
        }

        // GET: RecipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
