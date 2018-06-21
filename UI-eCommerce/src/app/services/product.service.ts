import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';


interface Product 
{
    Code : String,
    Name : String,
    Price : number,
    Description : String,
    Type : String,
    ShippingDeliveryType : String,
    imageURL : String,
    Category : Object
}


@Injectable()

export class ProductService
{
    constructor(private http:HttpClient)
    {}

    getProduct() 
    {
        const headers = new HttpHeaders()
        .set('Content-Type', 'application/json');

        return this.http.get<Product[]>('http://localhost:40097/api/product', {headers:headers});
    }
  
   getProduct2() 
    {
        const headers = new HttpHeaders()
        .set('Content-Type', 'application/json');

        return this.http.get<Product>('http://localhost:40097/api/product/id', {headers:headers});
    }
}