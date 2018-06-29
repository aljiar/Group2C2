import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductCart } from '../../models/product-cart';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { Store } from '../../models/store';

@Component({
  selector: 'app-product-cart',
  templateUrl: './product-cart.component.html',
  styleUrls: ['./product-cart.component.scss']
})
export class ProductCartComponent implements OnInit {

  @Input() productCart: ProductCart
  @Input() username: string
  @Input() index: number
  @Input() stores: Store[]
  @Output() productAdded: EventEmitter<[number, number, number]> = new EventEmitter()
  product: Product
  quantity: number
  inStore: boolean

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.quantity = 1;
    this.productService.getProduct2(this.productCart.ProductCode).subscribe(
      data => {
        this.product = data;
        this.productAdded.emit([this.index, 1, this.product.Price])
      },
      error => console.log(error)
    )
  }

  onChange(newValue) {
    var value = parseInt(newValue) - this.quantity;
    this.quantity = parseInt(newValue);
    this.productAdded.emit([this.index, value, this.product.Price*value])
  }

  onChangeDeliveryType(newValue: string) {
    this.inStore = false;
    if (newValue == "InStore") {
      this.inStore = true;
      this.stores = [{ "Name": "Everything you need", "Line1": "Av. Store", "Line2": "Store Av", "Phone": 123456}]
    }
  }
}
