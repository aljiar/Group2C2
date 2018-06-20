import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../http.service';
import { Address } from '../models/address';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-set-address',
  templateUrl: './set-address.component.html',
  styleUrls: ['./set-address.component.scss']
})
export class SetAddressComponent implements OnInit {

  getdata = {}
  constructor(private service: HttpService) { }

  shippingAddresses : Address[];
  

  ngOnInit() {
  this.getShippingAddresses();
  }

  resetForm(form?: NgForm) {
   if (form != null)
      form.reset();
    this.getdata = {
    Identifier : null,
    Line1 : '',
    Line2 : '',
    Phone : '',
    City : '',
    Zone : '',
    }
  }

  getShippingAddresses(){
    this.service.getInfo("getshippingAddresses",null).subscribe(
      res=>{
        console.log(res)
        this.shippingAddresses = res;
      },
      err=>{
        console.log(err)
      });
  }

  postShippingAddresses() {
    this.service.postInfo(this.getdata,"postshippingAddresses")
    .subscribe(
      res => console.log(res),
      err => console.log(err)
    )
  }

}
