import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Observable } from 'rxjs';
import {Router} from '@angular/router'; 

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  constructor(private userService: UserService, private router:Router) { 

  }

  ngOnInit() {
    if (localStorage.getItem('username')) {
      this.router.navigate([''])
    }
  }
  
  loginButtonPressed(form:NgForm){
    this.userService.getUserByUsername(form.value.username).subscribe(
      data => this.login(form.value.username, data),
      err => alert("Username does not exist")
    );
  }

  login(username: string, data){
    localStorage.setItem('username',username);
    this.router.navigate([''])
  }
}
