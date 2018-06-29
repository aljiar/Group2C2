import { Component, OnInit, Input } from '@angular/core';
import { ShippingAddress } from '../../models/shipping-address';

@Component({
  selector: 'app-shipping-address',
  templateUrl: './shipping-address.component.html',
  styleUrls: ['./shipping-address.component.scss']
})
export class ShippingAddressComponent implements OnInit {

  @Input() shippingAddress: ShippingAddress

  constructor() { }

  ngOnInit() {
  }

}
