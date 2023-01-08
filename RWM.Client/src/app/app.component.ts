import { Component, OnInit } from '@angular/core';
import { Book } from './models/book.model';
import { BookService } from './services/book.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  books: Book[] = [];
  private bookService: BookService;

  constructor(bookService: BookService){
      this.bookService = bookService;
  }

  ngOnInit(): void {
    this.bookService.getAllBooks()
    .subscribe(books => {
      this.books = books
    });
  }
}
