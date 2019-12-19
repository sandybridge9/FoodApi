import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {User} from '../models/User';
import {Cart} from '../models/Cart';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  apiUrl = 'https://localhost:44322/api/Cart';

  constructor(private http: HttpClient) {}

  getCarts(): Observable<Cart[]> {
    return this.http.get<Cart[]>(this.apiUrl);
  }

  getCartById(id: number): Observable<Cart> {
    return this.http.get<Cart>(this.apiUrl + '/' + id);
  }

  addCart(cart: Cart): Observable<Cart> {
    return this.http.post<Cart>(this.apiUrl, cart);
  }

  updateCart(cart: Cart): Observable<any> {
    return this.http.put(this.apiUrl + '/' + cart.Id, cart);
  }

  deleteCart(id: number): Observable<any>{
    return this.http.delete(this.apiUrl + '/' + id);
  }
}
