import { BrowserModule } from '@angular/platform-browser';
import { GlobalService } from "./globals.service";
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductDescriptionComponent } from './components/product-description/product-description.component';
import { ProductsComponent } from './components/products/products.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { ProductCartComponent } from './components/product-cart/product-cart.component';
import { AddressComponent } from './components/address/address.component';
import { SetAddressComponent } from './components/set-address/set-address.component';
import { ShippingAddressComponent } from './components/shipping-address/shipping-address.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductDescriptionComponent,
    ProductsComponent,
    LoginPageComponent,
    HomeComponent,
    NavbarComponent,
    ShoppingCartComponent,
    ProductCartComponent,
    AddressComponent,
    SetAddressComponent,
    ShippingAddressComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AngularFontAwesomeModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
