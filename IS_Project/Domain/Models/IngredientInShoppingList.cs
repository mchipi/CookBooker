using System;

namespace Domain.Models
{
    public class IngredientInShoppingList
    {
        public Guid ShoppingListId { get; set; }
        public virtual ShoppingList ShoppingList { get; set; }
        public Guid IngredientId { get; set; }
        public Guid RecipeId { get; set; }
        public virtual IngredientInRecipe Ingredient { get; set; }


    }
}
