import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cart } from '../models/cart';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http: HttpClient) { }

  getCartById(id: string) {
    return this.http.get<Cart>('http://localhost:40097/api/cart/' + id)
  }

  updateCart(id: string, cart: Cart) {

  }

  createCart(cart: Cart) {
    return this.http.post('http://localhost:40097/api/cart', cart)
  }
}
