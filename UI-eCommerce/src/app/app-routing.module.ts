import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginPageComponent} from './components/login-page/login-page.component';
import { combineLatest } from 'rxjs';

const routes: Routes = [
  {path: '', component:LoginPageComponent},
  {path: 'login', component:LoginPageComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
