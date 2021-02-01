import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl="http://localhost:62117/api"

  constructor(private http:HttpClient) { }

  getBookList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/books');
  }

  addBook(val:any){
    return this.http.post(this.APIUrl+'/Books',val);
  }

  updateBook(val:any){
    return this.http.put(this.APIUrl+'/Books',val);
  }

  getAllBookNames():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/books/GetAllBookNames'); 
  }
}
