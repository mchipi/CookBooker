using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ShoppingList> shoppingLists;
        private DbSet<IngredientInRecipe> ingredientsInRecipe;
        private DbSet<IngredientInShoppingList> ingredientInShoppingLists;

        public ShoppingListRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.shoppingLists = context.ShoppingLists;
            this.ingredientsInRecipe = context.IngredientInRecipes;
            this.ingredientInShoppingLists = context.IngredientInShoppingLists;
        }

        //public void AddIngredientsToShoppingList(Guid listId, Guid recipeId)
        //{
        //    throw new NotImplementedException();
        //}

        public ShoppingList CreateShoppingList()
        {
            ShoppingList shoppingList = new ShoppingList()
            {
                Id = Guid.NewGuid()
            };
            shoppingLists.Add(shoppingList);
            context.SaveChanges();
            return shoppingList;
        }

        public void AddNewIngredientInShoppingList (IngredientInShoppingList ingredientInShoppingList)
        {
            ingredientInShoppingLists.Add(ingredientInShoppingList);
            context.SaveChanges();
        }

        public List<IngredientInShoppingList> GetListById(Guid id)
        {
           List<IngredientInShoppingList> ingredientInShopping = ingredientInShoppingLists.Where(z => z.ShoppingListId == id)
                .Include(z => z.Ingredient)
                .Include(z => z.Ingredient.Ingredient).ToList();
            return ingredientInShopping;
        }
    }
}
