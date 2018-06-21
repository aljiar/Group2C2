import { Component, OnInit } from '@angular/core';
import { GlobalService } from "../../globals.service";

@Component({
  selector: 'app-third',
  templateUrl: './third.component.html',
  styleUrls: ['./third.component.scss'],
  providers: [GlobalService]
})
export class THIRDComponent implements OnInit {

  product;

  constructor(private service: GlobalService) { }

  ngOnInit() {
    this.service.getProduct2().subscribe(data => {
      this.product = data.product;
    })
  }

}
