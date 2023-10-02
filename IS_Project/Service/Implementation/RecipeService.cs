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
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository repository;
        private readonly IIngredientRepository ingredientRepository;
        public RecipeService(IRecipeRepository repository, IIngredientRepository ingredientRepository)
        {
            this.repository = repository;
            this.ingredientRepository = ingredientRepository;
        }


        public void addRecipe(RecipeDto recipeDto)
        {
            repository.addRecipe(recipeDto);
        }

        public List<Recipe> getRecipes()
        {
            return repository.getRecipes();
        }

        //public List<RecipeAndIngredientsDto> getRecipesWithIngredients()
        //{
        //    return repository.getRecipes().ForEach(recipe =>
        //    {
        //        ingredientRepository.GetListOfIngredients
        //    });
        //}

        public Recipe getRecipeDetails(Guid? id)
        {
            return repository.getRecipeDetails(id);
        }

        public Recipe addIngredientToRecipe(Guid recipeId, AddIngredientToRecipeDto addIngredientToRecipeDto)
        {
            return repository.addIngredientToRecipe(recipeId, addIngredientToRecipeDto);
        }
    }
}
