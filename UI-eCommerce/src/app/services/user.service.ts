import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { 

  }

  getUserByUsername(username) {
    return this.http.get('http://localhost:40097/api/user/'+username)
  }
}
