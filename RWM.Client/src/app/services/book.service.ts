import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http:HttpClient) { }

  public getAllBooks(){
    return this.http.get<Book[]>("http://localhost:api-host/Book/all");
  }
}
