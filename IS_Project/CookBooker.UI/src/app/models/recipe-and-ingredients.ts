import { IngredientQuantityUnit } from "./ingredient-quantity-unit";
import { Recipe } from "./recipe";

export class RecipeAndIngredients{
    ingredients : IngredientQuantityUnit[] = [];
    recipe : Recipe = new Recipe();
}