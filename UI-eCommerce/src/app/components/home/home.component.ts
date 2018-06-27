import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router'; 
import { CartService } from '../../services/cart.service';
import { Cart } from '../../models/cart';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  username: string

  constructor(private userService: UserService, private cartService: CartService, private router:Router) { }

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
      data => {},
      error => {
        if (error.status == 404)
        {
          var cart: Cart = { Username: this.username, ListProductCart: []}
          this.cartService.createCart(cart).subscribe(
            data => console.log(data),
            error => console.log(error)
          )
        }
      }
    )
  }
}
