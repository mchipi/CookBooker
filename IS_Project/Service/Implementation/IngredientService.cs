using Domain.Models;
using Domain.Models.DTO;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository repository;
        private readonly IRecipeRepository recipeRepository;
        public IngredientService(IIngredientRepository repository, IRecipeRepository recipeRepository)
        {
            this.repository = repository;
            this.recipeRepository = recipeRepository;
        }

        public void AddIngredient(string ingredientName)
        {
            repository.AddIngredient(ingredientName);
        }

        public RecipeAndIngredientsDto GetRecipeAndIngredients(Guid recipeId)
        {
            List<IngredientInRecipe> ingredients = repository.GetListOfIngredients(recipeId);
            Recipe recipe = recipeRepository.getRecipeDetails(recipeId);
            RecipeAndIngredientsDto recipeAndIngredientsDto = new RecipeAndIngredientsDto()
            {
                Recipe = recipe,
                Ingredients = ingredients
            };
            return recipeAndIngredientsDto;
        }


    }
}
