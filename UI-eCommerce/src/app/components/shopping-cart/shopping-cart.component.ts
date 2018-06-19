import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.scss']
})
export class ShoppingCartComponent implements OnInit {
  title='Shopping Cart';
  products_name=['Asus','Lenovo','Macbook','Samsung','Dell'];
  constructor() { }

  ngOnInit() {
  }

}
