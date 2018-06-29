import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";

@Component({
  selector: 'app-producs',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss'],
  providers: [ProductService]
})

export class ProductsComponent implements OnInit {

  products = [
      {  
        "Code" : "peraphone_xi", 
        "Name" : "Peraphone XI", 
        "Description" : "The new PeraphoneTM", 
        "Category" :  { "Name" : "Technology", "Description" : "All tech things" },
        "ShippingDeliveryType"  : "Express", 
        "Price" : 1299,
        "imageURL" : "https://k34.kn3.net/taringa/1/4/8/4/0/8/2/mariogca/31C.jpg", 
        "Type" : "Physical" 
    },
    { 
        "Code" : "gamesphere_5", 
        "Name" : "Gamesphere 5", 
        "Description" : "It's not a copy at all", 
        "Category" : { "Name" : "Entertainment", "Description" : "Fun stuff"},
        "ShippingDeliveryType"  : "InStore", 
        "Price" : 349, 
        "imageURL" : "https://i.redd.it/0458q1dd0d2z.jpg", 
        "Type" : "Physical" 
    },
    { 
        "Code" : "extreme_vg", 
        "Name" : "Extreme Video Game", 
        "Description" : "It's so XTREMEE", 
        "Category" : { "Name" : "Entertainment", "Description" : "Fun stuff" },
        "ShippingDeliveryType" : "None", 
        "Price" : 59, 
        "imageURL" : "https://images-na.ssl-images-amazon.com/images/I/41KbVOAvsBL.jpg",
        "Type" : "Digital"
    }
  ];

  constructor(private service: ProductService) { }

  ngOnInit() {
    /*this.service.getProduct().subscribe(data => {
      this.products = data;
    })*/
  }
}
