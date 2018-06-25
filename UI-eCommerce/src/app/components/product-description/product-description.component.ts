import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";

@Component({
  selector: 'app-product-description',
  templateUrl: './product-description.component.html',
  styleUrls: ['./product-description.component.scss'],
  providers: [ProductService]
})
export class ProductDescriptionComponent implements OnInit {

  product;

  constructor(private service: ProductService) { }

  ngOnInit() {
    this.service.getProduct().subscribe(data => {
      this.product = data;
    })
  }

}
