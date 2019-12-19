import { Injectable } from '@angular/core';
import {FoodItem} from '../models/FoodItem';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FoodItemService {
  apiUrl = 'https://localhost:44322/api/FoodItem';

  constructor(private http: HttpClient) {}

  getFoodItems(): Observable<FoodItem[]> {
    return this.http.get<FoodItem[]>(this.apiUrl);
  }

  getFoodItemById(id: number): Observable<FoodItem> {
    return this.http.get<FoodItem>(this.apiUrl + '/' + id);
  }

  addFoodItem(foodItem: FoodItem): Observable<FoodItem> {
    return this.http.post<FoodItem>(this.apiUrl, foodItem);
  }

  updateFoodItem(foodItem: FoodItem): Observable<any> {
    return this.http.put(this.apiUrl + '/' + foodItem.Id, foodItem);
  }

  deleteFoodItem(id: number): Observable<any>{
    return this.http.delete(this.apiUrl + '/' + id);
  }
}
