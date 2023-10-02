using Domain.Models;
using Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRecipeRepository
    {
        public List<Recipe> getRecipes();
        public Recipe getRecipeDetails(Guid? id);
        public void addRecipe(RecipeDto recipeDto);
        public Recipe addIngredientToRecipe(Guid recipeId, AddIngredientToRecipeDto addIngredientToRecipeDto);

    }
}
