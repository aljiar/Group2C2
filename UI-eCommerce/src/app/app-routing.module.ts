import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { ProductsComponent } from './components/products/products.component';
import { ProductDescriptionComponent } from './components/product-description/product-description.component';
import { HomeComponent } from './components/home/home.component';
import { combineLatest } from 'rxjs';

const routes: Routes = [
  {path: '', component:LoginPageComponent},
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
        path: 'productDescription',
        component: ProductDescriptionComponent
      }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
