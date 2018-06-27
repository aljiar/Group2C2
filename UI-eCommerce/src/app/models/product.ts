import { Category } from './category'

export class Product {
  Code : string
  Name : string
  Price : number
  Description : string
  Type : string
  ShippingDeliveryType : string
  imageURL : string
  Category : Category
}