import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Book } from 'src/app/models/book.model';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent {
  @Input() public bookComp?: Book;

  constructor(private router: Router){}
  
  public redirectToPage() {
    this.router.navigate(["/book"], {queryParams: {id: `${this.bookComp?.id}`}})
  }
}
