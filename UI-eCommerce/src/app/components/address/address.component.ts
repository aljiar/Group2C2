import { Component, OnInit } from '@angular/core';
import { ShippingAddress } from '../../models/shipping-address';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';
import { CartService } from '../../services/cart.service';
import { DataService } from '../../services/data.service';
import { Router } from '@angular/router'; 
import { Cart } from '../../models/cart';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {

  user: User
  cart: Cart
  edit: boolean
  oldShippingAddress: ShippingAddress

  constructor(private userService: UserService, private cartService: CartService, private dataService: DataService, private router: Router) { 
    this.edit = false;
  }

  ngOnInit() {
    var username = this.userService.getCurrentUsername();
    this.userService.getUserByUsername(username).subscribe(
      data => this.user = data,
      err => console.log(err)
    )
    this.cartService.getCartById(username).subscribe(
      data => this.cart = data,
      err => console.log(err)
    )
  }

  deleteAddress(identifier: string) {
    var index = this.user.ShippingAddressesList.findIndex(address => address.Identifier == identifier);
    if (index != -1) {
      this.user.ShippingAddressesList.splice(index, 1);
      this.userService.updateUserById(this.user.Username, this.user).subscribe(
        data => this.user = data,
        err => console.log(err)
      )
    }
  }

  deliver(identifier: string) {
    this.cart.Dispatched = true;
    this.cartService.updateCart(this.cart.Username, this.cart).subscribe(
      data => {
        console.log(data)
        this.dataService.resetData(true);
        var cart: Cart = { Username: this.user.Username, ListProductCart: [], Dispatched: false}
        this.cartService.createCart(cart).subscribe(
          data => console.log(data),
          error => console.log(error)
        )
        this.router.navigate(['/home/products'])
      },
      err => console.log(err)
    )
  }

  editAddress(address: ShippingAddress) {
    this.edit = true;
    this.oldShippingAddress = address;
  }

  cancelEdition() {
    this.oldShippingAddress = null;
    this.edit = false;
  }

  saveEditedAddress(shippingAddress: ShippingAddress) {
    var index = this.user.ShippingAddressesList.findIndex(address => address.Identifier == shippingAddress.Identifier);
    if (index != -1) {
      this.user.ShippingAddressesList[index] = shippingAddress;
      this.userService.updateUserById(this.user.Username, this.user).subscribe(
        data => this.user = data,
        err => console.log(err)
      )
    }  
  }

  saveNewAddress(shippingAddress: ShippingAddress) {
    if (this.checkIfIdentifierIsUnique(shippingAddress.Identifier)) {
      this.user.ShippingAddressesList.push(shippingAddress);
      this.userService.updateUserById(this.user.Username, this.user).subscribe(
        data => this.user = data,
        err => console.log(err)
      ) 
    }
    else {
      alert("Address identifier is not unique")
    }
  }

  submitAddress(data: [boolean, ShippingAddress]) {
    var edited = data[0]
    var newShippingAddress = data[1]
    if (edited) {
      this.saveEditedAddress(newShippingAddress);
    }
    else {
      this.saveNewAddress(newShippingAddress);
    }
  }

  checkIfIdentifierIsUnique(identifier: string) {
    var index = this.user.ShippingAddressesList.findIndex(address => address.Identifier == identifier);
    if (index == -1) {
      return true;
    }
    return false;
  }
}
