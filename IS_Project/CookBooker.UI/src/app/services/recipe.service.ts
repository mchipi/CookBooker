import { Injectable } from '@angular/core';
import { Recipe } from '../models/recipe';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { RecipeAndIngredients } from '../models/recipe-and-ingredients';
import { EmptyShoppingList } from '../models/empty-shopping-list';
import { ShoppingListWithRecipes } from '../models/shopping-list-recipes';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  private url = "Recipes";

  constructor(private http : HttpClient) { }

  public getRecipes() : Observable<Recipe[]>{
    return this.http.get<Recipe[]>(environment.apiUrl + "/" + this.url);
  }

  public detailsRecipe(id : string) : Observable<RecipeAndIngredients>{
    return this.http.get<RecipeAndIngredients>(environment.apiUrl + "/" + this.url +"/"+ id);
  }

  public createShoppingList() : Observable<EmptyShoppingList>{
    return this.http.get<EmptyShoppingList>(environment.apiUrl +"/"+ this.url +"/newCart");
  }

  public addIngredientsToShoppingList(listId : string, recipeId : string) : Observable<ShoppingListWithRecipes>{
    const link = "/addIngredientToCart?listId=" + listId + "&recipeId=" + recipeId;
    return this.http.post<ShoppingListWithRecipes>(environment.apiUrl +"/"+ this.url + link, {});
  }

  public getListById(id : string) : Observable<ShoppingListWithRecipes>{
    return this.http.get<ShoppingListWithRecipes>(environment.apiUrl + "/" + this.url +"/list/"+ id);
  }
}
