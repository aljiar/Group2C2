import { Component, OnInit } from '@angular/core';
import { ShippingAddress } from '../../models/shipping-address';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {

  user: User

  constructor(private userService: UserService) { }

  ngOnInit() {
    var username = this.userService.getCurrentUsername();
    this.userService.getUserByUsername(username).subscribe(
      data => this.user = data,
      err => console.log(err)
    )
  }

}
