import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShoppingListWithRecipes } from 'src/app/models/shopping-list-recipes';
import { RecipeService } from 'src/app/services/recipe.service';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent {
  id !: string;
  shoppingList !: ShoppingListWithRecipes;

  constructor(private recipeService: RecipeService, private route : ActivatedRoute){}

  
  ngOnInit() : void {
    this.id = String(this.route.snapshot.paramMap.get('id'));
    this.recipeService.getListById(this.id).subscribe((result : ShoppingListWithRecipes) => {
      console.log(result);
      this.shoppingList = result;
      console.log(this.shoppingList);
    });
  }

}
