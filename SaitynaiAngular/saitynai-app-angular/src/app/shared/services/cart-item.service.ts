import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Cart} from '../models/Cart';
import {CartItem} from '../models/CartItem';

@Injectable({
  providedIn: 'root'
})
export class CartItemService {
  apiUrl = 'https://localhost:44322/api/CartItem';

  constructor(private http: HttpClient) {}

  getCartItems(): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(this.apiUrl);
  }

  getCartItemById(id: number): Observable<CartItem> {
    return this.http.get<CartItem>(this.apiUrl + '/' + id);
  }

  addCartItem(cartItem: CartItem): Observable<CartItem> {
    return this.http.post<CartItem>(this.apiUrl, cartItem);
  }

  updateCartItem(cartItem: CartItem): Observable<any> {
    return this.http.put(this.apiUrl + '/' + cartItem.Id, cartItem);
  }

  deleteCartItem(id: number): Observable<any>{
    return this.http.delete(this.apiUrl + '/' + id);
  }
}
