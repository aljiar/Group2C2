import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { ProductsComponent } from './components/products/products.component';
import { ProductDescriptionComponent } from './components/product-description/product-description.component';
import { HomeComponent } from './components/home/home.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { AddressComponent } from './components/address/address.component';
import { combineLatest } from 'rxjs';

const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'login', component:LoginPageComponent},
  {
    path: 'home', 
    component:HomeComponent,
    children: [
      {
        path: 'products',
        component: ProductsComponent
      },
      {
        path: 'productDescription/:id',
        component: ProductDescriptionComponent
      },
      {
        path: 'cart',
        component: ShoppingCartComponent
      },
      {
        path: 'address',
        component: AddressComponent
      }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
