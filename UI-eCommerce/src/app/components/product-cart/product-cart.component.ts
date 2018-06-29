import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductCart } from '../../models/product-cart';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';

@Component({
  selector: 'app-product-cart',
  templateUrl: './product-cart.component.html',
  styleUrls: ['./product-cart.component.scss']
})
export class ProductCartComponent implements OnInit {

  @Input() productCart: ProductCart
  @Input() username: string
  @Input() index: number
  @Output() productAdded: EventEmitter<[number, number, number]> = new EventEmitter()
  product: Product
  quantity: number

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
}
