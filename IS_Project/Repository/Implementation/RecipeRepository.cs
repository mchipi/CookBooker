using Domain.Models;
using Domain.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Recipe> recipes;
        private DbSet<Ingredient> ingredients;
        private DbSet<IngredientInRecipe> ingredientsInRecipe;

        public RecipeRepository(ApplicationDbContext context )
        {
            this.context = context;
            this.recipes = context.Recipes;
            this.ingredients = context.Ingredients;
            this.ingredientsInRecipe = context.IngredientInRecipes;
        }

        public void addRecipe(RecipeDto recipeDto)
        {
            Recipe recipe = new Recipe()
            {
                Id = new Guid(),
                Title = recipeDto.Title,
                Description = recipeDto.Description,
                Instructions = recipeDto.Instructions,
                CookingTime = recipeDto.CookingTime,
                Servings = recipeDto.Servings,

            };
            recipes.Add(recipe);
            context.SaveChanges();
        }

        public Recipe getRecipeDetails(Guid? id)
        {
            return recipes.SingleOrDefault(s=>s.Id == id);
        }

        public List<Recipe> getRecipes()
        {
            return recipes.ToList();
        }

        public Recipe addIngredientToRecipe(Guid recipeId, AddIngredientToRecipeDto addIngredientToRecipeDto)
        {
            IngredientInRecipe ingredientInRecipe = new IngredientInRecipe()
            {
                RecipeId = recipeId,
                IngredientId = addIngredientToRecipeDto.IngredientId,
                Quantity = addIngredientToRecipeDto.Quantity,
                Unit = addIngredientToRecipeDto.Unit
            };
            ingredientsInRecipe.Add(ingredientInRecipe);
            context.SaveChanges();
            Recipe recipe = this.getRecipeDetails(recipeId);
            return recipe;
        }
    }
}
