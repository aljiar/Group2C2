import { Component, OnInit } from '@angular/core';
import { GlobalService } from "../../globals.service";

@Component({
  selector: 'app-second-page',
  templateUrl: './second-page.component.html',
  styleUrls: ['./second-page.component.scss'],
  providers: [GlobalService]
})

export class SecondPageComponent implements OnInit {

  products = [];

  constructor(private service: GlobalService) { }

  ngOnInit() {
    this.service.getProduct().subscribe(data => {
      this.products = data;
    })
  }
}
