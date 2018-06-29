import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ShippingAddress } from '../../models/shipping-address';

@Component({
  selector: 'app-shipping-address',
  templateUrl: './shipping-address.component.html',
  styleUrls: ['./shipping-address.component.scss']
})
export class ShippingAddressComponent implements OnInit {

  @Input() shippingAddress: ShippingAddress
  @Output() deleteAddress: EventEmitter<string> = new EventEmitter()
  @Output() deliverToAddress: EventEmitter<string> = new EventEmitter()
  @Output() editAddress: EventEmitter<ShippingAddress> = new EventEmitter()


  constructor() { }

  ngOnInit() {
  }

  delete() {
    this.deleteAddress.emit(this.shippingAddress.Identifier);
  }

  deliver() {
    this.deliverToAddress.emit(this.shippingAddress.Identifier);
  }

  edit() {
    this.editAddress.emit(this.shippingAddress);
  }
}
