import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http:HttpClient) { }

  public getAllBooks(){
    return this.http.get<Book[]>("http://localhost:7256/Book/all");
  }

  public getBook(bookId: string){
    return this.http.get<Book>(`http://localhost:7256/Book/${bookId}`)
  }
}
