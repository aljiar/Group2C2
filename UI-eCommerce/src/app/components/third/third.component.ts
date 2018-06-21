import { Component, OnInit } from '@angular/core';
import { GlobalService } from "../../globals.service";

@Component({
  selector: 'app-third',
  templateUrl: './third.component.html',
  styleUrls: ['./third.component.scss'],
  providers: [GlobalService]
})
export class ThirdComponent implements OnInit {

  products = [];

  constructor(private service: GlobalService) { }

  ngOnInit() {
    this.service.getProduct().subscribe(data => {
      this.products = data;
    })
  }

}
