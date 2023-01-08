import { R3BoundTarget } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Book } from './models/book.model';
import { BookService } from './services/book.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  books: Book[] = [];

  public searchQuery: string = "";
  public filteredBooks: Book[] = [];
  private dummyOne: Book = {
    id: "12961307-justice",
    title: "Justice",
    series: "New Species #4",
    author: "Laurann Dohner",
    pages: 222,
    coverImgUrl: "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1319618114l/12961307.jpg",
    description: "desc"  
  };
  private dummyTwo: Book = {
    id: "12961307-justice",
    title: "Justice is served",
    series: "New Species #4",
    author: "Laurann Dohner",
    pages: 222,
    coverImgUrl: "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1319618114l/12961307.jpg",
    description: "desc"  
  };

  constructor(private bookService: BookService){}

  ngOnInit(): void {
    this.bookService.getAllBooks()
    .subscribe(books => {
      this.books = books
    });
    this.books = [this.dummyOne, this.dummyTwo];
  }

  public filterBooks(){
    this.filteredBooks = this.books.filter(b => b.title.includes(this.searchQuery) || b.author.includes(this.searchQuery))
  }

}

