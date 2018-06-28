import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router'; 
import { CartService } from '../../services/cart.service';
import { Cart } from '../../models/cart';
import { DataService } from '../../services/data.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [DataService]
})
export class HomeComponent implements OnInit {

  username: string
  numberOfProducts: number

  constructor(private userService: UserService, private cartService: CartService, private dataService: DataService, private router:Router) { 
    this.numberOfProducts = 0
    dataService.numberOfProducts$.subscribe(
      number => {
        this.numberOfProducts++;
    })
  }

  ngOnInit() {
    this.username = this.userService.getCurrentUsername()
    if (this.username == null || this.username == undefined) {
      this.router.navigate(['login'])
    }
    else {
      this.validateCart()
    }
  }

  validateCart() {
    this.cartService.getCartById(this.username).subscribe(
      data => {
        this.numberOfProducts = data.ListProductCart.length
      },
      error => {
        if (error.status == 404)
        {
          var cart: Cart = { Username: this.username, ListProductCart: [], Dispatched: false}
          this.cartService.createCart(cart).subscribe(
            data => console.log(data),
            error => console.log(error)
          )
        }
      }
    )
  }
}
