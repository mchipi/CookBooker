using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTO
{
    public class RecipeAndIngredientsDto
    {
        public Recipe Recipe { get; set; }
        public List<IngredientInRecipe> Ingredients { get; set; }
    }
}
