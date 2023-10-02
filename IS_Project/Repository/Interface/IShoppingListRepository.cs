using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IShoppingListRepository
    {
        public ShoppingList CreateShoppingList();
        //void AddIngredientsToShoppingList(Guid listId, Guid recipeId);
        public void AddNewIngredientInShoppingList(IngredientInShoppingList ingredientInShoppingList);
        public List<IngredientInShoppingList> GetListById(Guid id);
    }
}
