import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private _serviceUrl = "http://localhost:55014/api/"
  constructor(private http: HttpClient) { }
  postInfo(object,_serviceUri:String){
    let _url:string = this._serviceUrl+_serviceUri;
    return this.http.post<any>(_url, object);
  }
  getInfo(_serviceUri:String,key:String){
    let _url:string;
    if (key != null) {
      _url = this._serviceUrl+_serviceUri+"/"+key;
    }else{
      _url = this._serviceUrl+_serviceUri;
    }
    return this.http.get<any>(_url);
  }
  updateInfo(object,_serviceUri:String,key:String){
    let _url:string = this._serviceUrl+_serviceUri+"/"+key;
    return this.http.put<any>(_url, object);
  }
  deleteInfo(_serviceUri:String,key:String){
    let _url:string = this._serviceUrl+_serviceUri+"/"+key;
    return this.http.delete<any>(_url);
  }
}
