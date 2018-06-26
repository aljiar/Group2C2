import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";
import { ActivatedRoute } from "@angular/router";
import { Location } from "@angular/common";

@Component({
  selector: 'app-product-description',
  templateUrl: './product-description.component.html',
  styleUrls: ['./product-description.component.scss'],
  providers: [ProductService]
})
export class ProductDescriptionComponent implements OnInit {

  product;
  id: string;

  constructor(private service: ProductService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.service.getProduct2(this.id).subscribe(data => {
      this.product = data;
    })
  }

}
