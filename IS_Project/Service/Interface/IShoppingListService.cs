using Domain.Models;
using Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IShoppingListService
    {
        public ShoppingList CreateShoppingList();
        ShoppingListRecipeDto AddIngredientsToShoppingList(Guid listId, Guid recipeId);
        public List<IngredientInShoppingList> GetListById(Guid id);
        public ShoppingListRecipeDto GetShoppingListRecipes(Guid id);
    }
}
