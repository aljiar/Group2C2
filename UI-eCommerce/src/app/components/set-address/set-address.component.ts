import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ShippingAddress} from '../../models/shipping-address';
import { NgForm, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-set-address',
  templateUrl: './set-address.component.html',
  styleUrls: ['./set-address.component.scss']
})
export class SetAddressComponent implements OnInit {

  @Input() edit: boolean
  @Input() oldShippingAddress: ShippingAddress
  @Output() cancel: EventEmitter<boolean> = new EventEmitter()
  @Output() address: EventEmitter<[boolean, ShippingAddress]> = new EventEmitter()
  addressForm: FormGroup

  constructor() { }

  ngOnInit() {
    this.addressForm = new FormGroup({
      'identifier': new FormControl('', Validators.required),
      'addressOne': new FormControl('', Validators.required),
      'addressTwo': new FormControl('', Validators.required),
      'city': new FormControl('', Validators.required),
      'phone': new FormControl('', Validators.required),
      'zone': new FormControl('', Validators.required)
    })
  }

  submitAddress() {
    var newShippingAddress = {
      Identifier: this.addressForm.get('identifier').value,
      Line1: this.addressForm.get('addressOne').value,
      Line2: this.addressForm.get('addressTwo').value,
      Phone: this.addressForm.get('phone').value,
      City: this.addressForm.get('city').value,
      Zone: this.addressForm.get('zone').value
    };
    if (this.edit) {
      this.address.emit([true, newShippingAddress]);
    }
    else {
      this.address.emit([false, newShippingAddress]);
    }
    this.reset();
  }

  reset() {
    this.addressForm.reset();
    this.edit = false;
    this.cancel.emit(true);
    this.addressForm.controls['identifier'].enable();
  }

  editAddress() {
    if (this.edit) {
      this.addressForm.setValue({
        identifier: this.oldShippingAddress.Identifier,
        addressOne: this.oldShippingAddress.Line1,
        addressTwo: this.oldShippingAddress.Line2,
        city: this.oldShippingAddress.City,
        phone: this.oldShippingAddress.Phone,
        zone: this.oldShippingAddress.Zone
      })
      this.addressForm.controls['identifier'].disable();
    }
  }

  ngOnChanges() {
    this.editAddress();
  }
}
