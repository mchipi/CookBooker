using Domain.Models;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Implementation;
using Service.Interface;

namespace CookBooker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IIngredientService _ingredientService;
        private readonly IShoppingListService _shoppingListService;

        public RecipesController(IRecipeService _recipeService, IIngredientService _ingredientService, IShoppingListService shoppingListService)
        {
            this._recipeService = _recipeService;
            this._ingredientService = _ingredientService;
            this._shoppingListService = shoppingListService;
        }

        [HttpGet]
        public List<Recipe> GetRecipes()
        {
            return _recipeService.getRecipes();
        }

        [HttpGet("list")]
        public List<RecipeAndIngredientsDto> GetRecipesWithIngredients()
        {
            List<Recipe> recipes = _recipeService.getRecipes();
            List<RecipeAndIngredientsDto> list = new List<RecipeAndIngredientsDto>();
            foreach (Recipe recipe in recipes)
            {
                RecipeAndIngredientsDto recipeWithIngredients = _ingredientService.GetRecipeAndIngredients(recipe.Id);
                list.Add(recipeWithIngredients);
            }
            return list;
        }

        [HttpGet("{id}")]
        public RecipeAndIngredientsDto GetRecipeDetails(Guid id)
        {
            return _ingredientService.GetRecipeAndIngredients(id);
        }

        [HttpPost]
        public void AddNewRecipe(RecipeDto recipeDto)
        {
            _recipeService.addRecipe(recipeDto);
        }

        
        [HttpPost("/addIngredient")]
        public void addIngredient(string ingredient)
        {
            _ingredientService.AddIngredient(ingredient);
        }

        [HttpPost("addIngredientToRecipe")]
        public void addIngredientToRecipe(Guid recipeId, AddIngredientToRecipeDto addIngredientToRecipeDto)
        {
            _recipeService.addIngredientToRecipe(recipeId, addIngredientToRecipeDto);
        }

        [HttpGet("newCart")]
        public ShoppingList createCart()
        {
            return _shoppingListService.CreateShoppingList();
        }

        [HttpPost("addIngredientToCart")]
        public ShoppingListRecipeDto addIngredientToCart(Guid listId, Guid recipeId)
        {
            return _shoppingListService.AddIngredientsToShoppingList(listId, recipeId);
        }

        [HttpGet("cart/{id}")]
        public List<IngredientInShoppingList> getCartById(Guid id)
        {
            return _shoppingListService.GetListById(id);
        }

        [HttpGet("list/{id}")]
        public ShoppingListRecipeDto getListById(Guid id)
        {
            return _shoppingListService.GetShoppingListRecipes(id);
        }
    }
}
