import { R3BoundTarget } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Book } from '../../models/book.model';
import { BookService } from '../../services/book.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  books: Book[] = [];

  public searchQuery: string = "";
  public filteredBooks: Book[] = [];

  constructor(private bookService: BookService){}

  ngOnInit(): void {
    this.bookService.getAllBooks()
    .subscribe(books => {
      this.books = books
    });
    //this.books = [this.dummyOne, this.dummyTwo];
  }

  public filterBooks(){
    this.filteredBooks = this.books.filter(b => b.title.toLowerCase().includes(this.searchQuery.toLowerCase()) || b.author.toLowerCase().includes(this.searchQuery.toLowerCase()))
  }

  submit(event: KeyboardEvent){
    if(event.key === "Enter"){
      this.filterBooks();
    }
    console.log(event.key);
  }
}

