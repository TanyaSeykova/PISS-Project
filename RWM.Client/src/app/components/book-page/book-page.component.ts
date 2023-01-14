import { Component } from '@angular/core';
import { Comment } from '../../models/comment.model';
import { Book } from '../../models/book.model';
import { ActivatedRoute } from '@angular/router';

import { CommentService } from '../../services/comment.service'
import { BookService } from 'src/app/services/book.service';
@Component({
  selector: 'app-book-page',
  templateUrl: './book-page.component.html',
  styleUrls: ['./book-page.component.css']
})
export class BookPageComponent {
  protected book: Book = {id: "",  title: "" , series: "" , author: "", description: "",  pages: 0, coverImgUrl: ""};
  protected comments: Comment[] = [];
  constructor(private route: ActivatedRoute, private commentsService: CommentService, private bookService: BookService) { }

  ngOnInit(){
    this.route.queryParams.subscribe(params => {
      this.bookService.getBook(params['id']).subscribe(book => {this.book = book});
    });
   
  }
  

  showComments() {

    const page = document.getElementById("book-page") as HTMLInputElement;
    page?.addEventListener('page', this.getValue);

    this.commentsService.getCommentsBefore(this.book.id, +page.value)
      .subscribe(comments => {
        this.comments = comments.reverse()
      });
  }

  getValue(event: any) {
    const target = event.target as HTMLInputElement;
    console.log(target.value);
  }

  generateId() {
    return "3fa85f64-5717-4562-b3fc-2c963f66afa6";
  }

  publish() {

    const username = document.getElementById('username-input') as HTMLInputElement | null;
    const commentText = document.getElementById('comment-textarea') as HTMLTextAreaElement | null;
    const page = document.getElementById('page-input') as HTMLInputElement | null;


    username?.addEventListener('username', this.getValue);
    console.log("usrnm is ", (username || {}).value);
    if (username!.value == '' || username!.value == null) {
      document.getElementById('username-input-null-warning')?.removeAttribute('hidden');
      return;
    }
    else {
      document.getElementById('username-input-null-warning')?.setAttribute('hidden', '');
    }


    commentText?.addEventListener('commentText', this.getValue);
    console.log("comment is ", (commentText || {}).value);
    if (commentText!.value == '') {
      document.getElementById('comment-textarea-null-warning')?.removeAttribute('hidden');
      return;
    }
    else {
      document.getElementById('comment-textarea-null-warning')?.setAttribute('hidden', '');
    }


    page?.addEventListener('page', this.getValue);
    console.log("page is ", (page || {}).value);
    if (page!.value == '') {
      document.getElementById('book-page-null-warning')?.removeAttribute('hidden');
      return;
    }
    else if (+(page!.value) < 0 || +(page!.value) > 324)//EDIT THIS TO BE THE REAL NUMBER OF PAGES
    {
      document.getElementById('book-page-number-warning')?.removeAttribute('hidden');
      return;
    }
    else {
      document.getElementById('book-page-null-warning')?.setAttribute('hidden', '');
      document.getElementById('book-page-number-warning')?.setAttribute('hidden', '');
    }

    const comment: Comment = { id: this.generateId(), username: username!.value, text: commentText!.value, page: +page!.value, bookId: this.book.id };
    this.comments.unshift(comment);
    this.commentsService.addComment(comment);

  }
}
