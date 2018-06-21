import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";

@Component({
  selector: 'app-third',
  templateUrl: './third.component.html',
  styleUrls: ['./third.component.scss'],
  providers: [ProductService]
})
export class THIRDComponent implements OnInit {

  product;

  constructor(private service: ProductService) { }

  ngOnInit() {
    this.service.getProduct2().subscribe(data => {
      this.product = data.product;
    })
  }

}
