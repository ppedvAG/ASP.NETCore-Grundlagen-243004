﻿using BusinessLogic.Contracts;
using BusinessLogic.Data;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly FoodDeliveryDbContext _context;

        public RecipeService(FoodDeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Recipe>> GetAllRecipes(int pageIndex, int pageSize = 20)
        {
            var count = await _context.Recipes.CountAsync();
            var items = await _context.Recipes
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PaginatedList<Recipe>(items, count, pageIndex, pageSize);
        }

        public Task<Recipe?> GetRecipeById(int id)
        {
            return _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            _context.Update(recipe);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRecipe(int id)
        {
            var recipe = await GetRecipeById(id);
            if (recipe == null)
            {
                return false;
            }

            _context.Recipes.Remove(recipe);

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
