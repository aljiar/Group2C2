import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginPageComponent} from './components/login-page/login-page.component';
import { SecondPageComponent } from './components/second-page/second-page.component';
import { ThirdComponent } from './components/third/third.component';
import { combineLatest } from 'rxjs';

const routes: Routes = [
  {path: '', component:LoginPageComponent},
  {path: 'login', component:LoginPageComponent},
  {path: 'secondPage', component:SecondPageComponent},
  {path: 'thirdPage', component:ThirdComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
