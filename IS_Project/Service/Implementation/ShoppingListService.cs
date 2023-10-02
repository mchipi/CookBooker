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
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository shoppingListRepository;
        private readonly IRecipeRepository recipeRepository;
        private readonly IIngredientRepository ingredientRepository;
        public ShoppingListService(IShoppingListRepository shoppingListRepository, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            this.shoppingListRepository = shoppingListRepository;
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
        }

        

        public ShoppingListRecipeDto AddIngredientsToShoppingList(Guid listId, Guid recipeId)
        {
            ShoppingListRecipeDto shoppingList = this.GetShoppingListRecipes(listId);
            List<IngredientInRecipe> ingredients = ingredientRepository.GetListOfIngredients(recipeId);
            foreach(IngredientInRecipe ingredientInRecipe in ingredients)
            {
                IngredientInShoppingList ingredientInShoppingList = new IngredientInShoppingList()
                {
                    ShoppingListId = listId,
                    IngredientId = ingredientInRecipe.IngredientId,
                    RecipeId = recipeId
                };
                shoppingListRepository.AddNewIngredientInShoppingList(ingredientInShoppingList);
            }
            return shoppingList;
        }

        public ShoppingList CreateShoppingList()
        {
            return shoppingListRepository.CreateShoppingList();
        }

        public List<IngredientInShoppingList> GetListById(Guid id)
        {
            return shoppingListRepository.GetListById(id);
        }

        public ShoppingListRecipeDto GetShoppingListRecipes(Guid id)
        {
            List<IngredientInShoppingList> originalList = shoppingListRepository.GetListById(id);

            var shoppingListRecipes = originalList
                .GroupBy(item => item.ShoppingListId)
                .Select(group => new ShoppingListRecipeDto
                {
                    ShoppingListId = group.Key,
                    RecipeIds = group.Select(item => item.RecipeId).Distinct().ToList()
                })
                    .FirstOrDefault();

            return shoppingListRecipes;
        }
    }
}
