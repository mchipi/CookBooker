import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Recipe } from 'src/app/models/recipe';
import { RecipeAndIngredients } from 'src/app/models/recipe-and-ingredients';
import { EmptyShoppingList } from 'src/app/models/empty-shopping-list';
import { RecipeService } from 'src/app/services/recipe.service';
import { ShoppingListWithRecipes } from 'src/app/models/shopping-list-recipes';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})
export class RecipeDetailsComponent {
  recipe : RecipeAndIngredients = new RecipeAndIngredients();
  emptyList !: EmptyShoppingList;
  shoppingList !: ShoppingListWithRecipes;
  listId !: string;
  id !: string;

  constructor(private recipeService: RecipeService, private route : ActivatedRoute){}

  
  ngOnInit() : void {
    this.id = String(this.route.snapshot.paramMap.get('id'));
    this.recipeService.detailsRecipe(this.id).subscribe((result : RecipeAndIngredients) => {
      console.log(result);
      this.recipe = result;
      console.log(this.recipe);
      console.log(this.recipe.recipe.title);
      console.log("local storage var: " + localStorage.getItem('shoppingListId'));
      // localStorage.removeItem('shoppingListId');
    });
  }

  onClick() : void{
    if (localStorage.getItem('shoppingListId'))
    {
      this.listId = localStorage.getItem('shoppingListId') || ""
      console.log("list id: " + this.listId);
      this.recipeService.addIngredientsToShoppingList(this.listId, this.id).subscribe((result : ShoppingListWithRecipes) => {
        this.shoppingList = result;
        console.log(this.shoppingList);
      });
    }
    else
    {
      console.log("shopping list created")
      this.recipeService.createShoppingList().subscribe((result : EmptyShoppingList) => {
        this.emptyList = result;
        console.log("shopping list id: "+ this.emptyList.id);
        localStorage.setItem('shoppingListId',this.emptyList.id);
      });
    }
  }

}
