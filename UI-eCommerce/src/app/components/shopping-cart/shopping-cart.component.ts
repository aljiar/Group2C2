import { Component, OnInit } from '@angular/core';
import { Cart } from '../../models/cart';
import { CartService } from '../../services/cart.service';
import { UserService } from '../../services/user.service';
import { Route, Router } from '@angular/router';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.scss']
})
export class ShoppingCartComponent implements OnInit {
  cart : Cart
  totalItems: number
  totalPrice: number
  username: string

  constructor(private userService: UserService, private cartService: CartService, private dataService: DataService, private router: Router) { 
    this.totalItems = 0;
    this.totalPrice = 0;
  }

  ngOnInit() {
    this.username = this.userService.getCurrentUsername() 
    this.cartService.getCartById(this.username).subscribe(
      data => {
        this.cart = data;
        this.dataService.updateData(-this.cart.ListProductCart.length);
      },
      error => console.log(error)
    )
  }

  productAdded(data: [number, number, number]) {
    this.totalItems += data[1];
    this.totalPrice += data[2];
    this.cart.ListProductCart[data[0]].Quantity += data[1];
    this.dataService.updateData(data[1]);
  }

  next() {
    this.cartService.updateCart(this.username, this.cart).subscribe(
      data => {
        console.log(data);
        this.router.navigate(['/address']);
      },
      err => console.log(err)
    )
  }
} 