using Domain.Models;
using Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRecipeService
    {
        public List<Recipe> getRecipes();
        public void addRecipe(RecipeDto recipeDto);
        public Recipe getRecipeDetails(Guid? id);
        public Recipe addIngredientToRecipe(Guid recipeId, AddIngredientToRecipeDto addIngredientToRecipeDto);
    }
}
