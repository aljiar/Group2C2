import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductCart } from '../models/product-cart';

@Injectable({
  providedIn: 'root'
})
export class ProductCartService {

  constructor(private http: HttpClient) { }

  createProductCart(username: string, productCart: ProductCart) {
    return this.http.post('http://localhost:40097/api/productCart/' + username, productCart)
  }

  getProductCarts(cartId: string) {
    return this.http.get<ProductCart[]>('http://localhost:40097/api/productCart/' + cartId)
  }

  getProductCartById(cartId: string, productCartId: string) {
    return this.http.get<ProductCart[]>('http://localhost:40097/api/productCart/' + cartId + '/' + productCartId)
  }
}
