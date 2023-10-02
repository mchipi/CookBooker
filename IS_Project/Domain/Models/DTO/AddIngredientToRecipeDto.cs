using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTO
{
    public class AddIngredientToRecipeDto
    {
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
    }
}
