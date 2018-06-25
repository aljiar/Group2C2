import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  username: string
  name: string

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.username = localStorage.getItem('username')
    this.userService.getUserByUsername(this.username).subscribe(
      data => this.name = data.Name + " "+ data.LastName,
      error => console.error(error)
    );
  }

}
