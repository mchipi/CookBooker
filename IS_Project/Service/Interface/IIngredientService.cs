using Domain.Models;
using Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IIngredientService
    {
        void AddIngredient(string ingredientName);
        public RecipeAndIngredientsDto GetRecipeAndIngredients(Guid recipeId);
    }
}
