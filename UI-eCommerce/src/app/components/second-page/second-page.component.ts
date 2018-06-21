import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";

@Component({
  selector: 'app-second-page',
  templateUrl: './second-page.component.html',
  styleUrls: ['./second-page.component.scss'],
  providers: [ProductService]
})

export class SecondPageComponent implements OnInit {

  products = [];

  constructor(private service: ProductService) { }

  ngOnInit() {
    this.service.getProduct().subscribe(data => {
      this.products = data;
    })
  }
}
