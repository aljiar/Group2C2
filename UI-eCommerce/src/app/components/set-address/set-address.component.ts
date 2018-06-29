import { Component, OnInit } from '@angular/core';
import { ShippingAddress} from '../../models/shipping-address';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-set-address',
  templateUrl: './set-address.component.html',
  styleUrls: ['./set-address.component.scss']
})
export class SetAddressComponent implements OnInit {

  shippingAddresses : ShippingAddress[];
  
  constructor() { }

  ngOnInit() {
  }

  resetForm(form?: NgForm) {
   /*if (form != null)
      form.reset();
    this.getdata = {
    Identifier : null,
    Line1 : '',
    Line2 : '',
    Phone : '',
    City : '',
    Zone : '',
    }
    */
  }

  

}
