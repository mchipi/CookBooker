import { Component } from '@angular/core';
import { Recipe } from 'src/app/models/recipe';
import { RecipeService } from 'src/app/services/recipe.service';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent {
  title = 'CookBooker.UI';
  recipes: Recipe[] = []; 
  filteredRecipes: Recipe[] = [];
  private _filter : string = '';

  get filter() : string {
    return this._filter;
  }

  set filter(filterString: string){
    this._filter=filterString;
    console.log("filter is: " + filterString);
    this.filteredRecipes = this.performFilter(filterString);
  }

  constructor(private recipeService: RecipeService){}

  performFilter(filterBy: string) : Recipe[]{
    filterBy = filterBy.toLocaleLowerCase();
    return this.recipes.filter((recipe: Recipe) => 
      recipe.title.toLocaleLowerCase().includes(filterBy));
  }

  ngOnInit() : void {
    this.recipeService.getRecipes().subscribe((result : Recipe[]) => (this.recipes = result, this.filteredRecipes = result));
  }
}
