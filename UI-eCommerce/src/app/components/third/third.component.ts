import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";

@Component({
  selector: 'app-third',
  templateUrl: './third.component.html',
  styleUrls: ['./third.component.scss'],
  providers: [ProductService]
})
export class ThirdComponent implements OnInit {

  product;

  constructor(private service: ProductService) { }

  ngOnInit() {
    this.service.getProduct().subscribe(data => {
      this.product = data;
    })
  }

}
