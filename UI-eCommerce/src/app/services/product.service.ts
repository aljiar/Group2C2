import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Product } from '../models/product'

@Injectable({
    providedIn: 'root'
})

export class ProductService
{
    constructor(private http:HttpClient)
    {}

    getProduct() {
        const headers = new HttpHeaders()
        .set('Content-Type', 'application/json');

        return this.http.get<Product[]>('http://localhost:40097/api/product', {headers:headers});
    }
  
   getProduct2(id) {
        const headers = new HttpHeaders()
        .set('Content-Type', 'application/json');

        return this.http.get<Product>('http://localhost:40097/api/product/' + id, {headers:headers});
    }
}