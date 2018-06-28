import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";
import { ActivatedRoute } from "@angular/router";
import { ProductCartService } from '../../services/product-cart.service';
import { UserService } from '../../services/user.service';
import { Product } from '../../models/product';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-product-description',
  templateUrl: './product-description.component.html',
  styleUrls: ['./product-description.component.scss'],
  providers: [ProductService]
})
export class ProductDescriptionComponent implements OnInit {

  product: Product
  username: string

  constructor(private productService: ProductService, private productCartService: ProductCartService, private userService: UserService, private dataService: DataService, private route: ActivatedRoute) { }

  ngOnInit() {
    var id = this.route.snapshot.paramMap.get('id');
    this.username = this.userService.getCurrentUsername();
    this.productService.getProduct2(id).subscribe(data => {
      this.product = data;
    })
  }

  addToCart() {
    var productCart = {
      ProductCode: this.product.Code,
      SelectedDelivery: this.product.ShippingDeliveryType,
      Store: { Name: "Everything you need", Line1: "Av. Store", Line2: "Store Av", Phone: 123456}, //fake store
      Quantity: 1
    }
    this.productCartService.createProductCart(this.username, productCart).subscribe(
      data => {
        console.log(data)
        this.dataService.updateData()
      },
      err => console.log(err)
    )
  }
}
