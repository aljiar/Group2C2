import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  constructor(private userService: UserService) { 

  }

  ngOnInit() {
  }
  
  login(form:NgForm){
    this.userService.getUserByUsername(form.value.username).subscribe(
      data => console.log("Awesome"),
      err => console.log("Error")
    );
  }
}
