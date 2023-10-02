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
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Recipe> recipes;
        private DbSet<Ingredient> ingredients;
        private DbSet<IngredientInRecipe> recipeIngredients;

        public IngredientRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.recipes = context.Recipes;
            this.ingredients = context.Ingredients;
            this.recipeIngredients = context.IngredientInRecipes;
        }
        public void AddIngredient(string ingredientName)
        {
            {
                Ingredient ingredient = new Ingredient()
                {
                    Id = new Guid(),
                    Name = ingredientName,

                };
                ingredients.Add(ingredient);
                context.SaveChanges();
            }
        }

        public List<IngredientInRecipe> GetListOfIngredients(Guid recipeId)
        {
            List<IngredientInRecipe> ingredients = recipeIngredients.Where(z => z.RecipeId == recipeId).Include(x => x.Ingredient).ToList();
            return ingredients;
        }
    }
}
