import { Component, OnInit, Input } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router'; 

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  username: string
  name: string
  @Input() numberOfProducts: number

  constructor(private userService: UserService, private router:Router) { }

  ngOnInit() {
    this.username = this.userService.getCurrentUsername()
    this.userService.getUserByUsername(this.username).subscribe(
      data => this.name = data.Name + " " + data.LastName,
      error => console.error(error)
    );
  }
}
