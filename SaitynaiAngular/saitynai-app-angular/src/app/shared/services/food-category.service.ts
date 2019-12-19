import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {FoodCategory} from '../models/FoodCategory';

@Injectable({
  providedIn: 'root'
})
export class FoodCategoryService {
  apiUrl = 'https://localhost:44322/api/FoodCategory';

  constructor(private http: HttpClient) {}

  getFoodCategories(): Observable<FoodCategory[]> {
    return this.http.get<FoodCategory[]>(this.apiUrl);
  }

  getFoodCategoryById(id: number): Observable<FoodCategory> {
    return this.http.get<FoodCategory>(this.apiUrl + '/' + id);
  }

  addFoodCategory(foodCategory: FoodCategory): Observable<FoodCategory> {
    return this.http.post<FoodCategory>(this.apiUrl, foodCategory);
  }

  updateFoodCategory(foodCategory: FoodCategory): Observable<any> {
    return this.http.put(this.apiUrl + '/' + foodCategory.Id, foodCategory);
  }

  deleteFoodCategory(id: number): Observable<any>{
    return this.http.delete(this.apiUrl + '/' + id);
  }
}
