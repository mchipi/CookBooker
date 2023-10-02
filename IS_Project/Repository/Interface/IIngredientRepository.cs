using Domain.Models;
using Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IIngredientRepository
    {
        void AddIngredient(string ingredientName);
        List<IngredientInRecipe> GetListOfIngredients(Guid recipeId);
    }
}
