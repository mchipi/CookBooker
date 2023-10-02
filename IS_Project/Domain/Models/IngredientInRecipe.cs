using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class IngredientInRecipe
    {
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public Guid IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        [Required]
        public float Quantity { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}
