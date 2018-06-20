import { Component, OnInit } from '@angular/core';
import { ShoppingCart } from '../models/shopping-cart';
import { Product } from '../models/product';
import { HttpService } from '../../http.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.scss']
})
export class ShoppingCartComponent implements OnInit {
  title='Shopping Cart';
  products_name=['Asus','Lenovo','Macbook','Samsung','Dell'];
  constructor(private allService: HttpService) { }
  
  products : Product[];
  cart : ShoppingCart;
  totalItems: number = 0;
  totalPrice: number = 0;
  ngOnInit() {

    this.getCart();

  }

  getCart(){
    this.allService.getInfo("getCart", "user1").subscribe(
      response => {
        console.log(response);
        this.cart = response;
          this.getProducts();
      },
      error => {
        console.log(error);
      }

    );
  }
  getProducts(){
    this.allService.getInfo("getproducts","").subscribe(
      response => {
        console.log(response);
        this.products = response;
      },
      error => {
        console.log(error);
      }

    );
  }

}
