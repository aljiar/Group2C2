import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { User } from '../models/user';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUserByUsername(username:string) {
    return this.http.get<User>('http://localhost:40097/api/user/'+username)
  }

  getCurrentUsername() {
    return localStorage.getItem('username')
  }

  setCurrentUsername(username:string) {
    localStorage.setItem('username', username)
  }

  logout() {
    localStorage.removeItem('username')
  }
}
