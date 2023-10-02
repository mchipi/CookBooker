using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DTO
{
    public class ShoppingListRecipeDto
    {
        public Guid ShoppingListId { get; set; }
        public List<Guid> RecipeIds { get; set; }
    }
}
