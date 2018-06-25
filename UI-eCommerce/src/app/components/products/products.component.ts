import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";

@Component({
  selector: 'app-producs',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
  providers: [ProductService]
})

export class ProductsComponent implements OnInit {

  products = [];

  constructor(private service: ProductService) { }

  ngOnInit() {
    this.service.getProduct().subscribe(data => {
      this.products = data;
    })
  }
}
