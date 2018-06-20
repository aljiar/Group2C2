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

interface ResponseObject
{
    products : Product[]
}


@Injectable()

export class GlobalService
{
    constructor(private http:HttpClient)
    {}

    getProduct() 
    {
        const headers = new HttpHeaders()
        .set('Content-Type', 'application/json');
        return this.http.get<ResponseObject>('/api/Product', {headers:headers});
    }
}