import { Component } from '@angular/core';
import { Comment } from '../../models/comment.model';
import { ActivatedRoute } from '@angular/router';

import { CommentService } from '../../services/comment.service'
@Component({
  selector: 'app-book-page',
  templateUrl: './book-page.component.html',
  styleUrls: ['./book-page.component.css']
})
export class BookPageComponent {
  private bookId: string = "d804ab37-c31d-41be-388c-08daf63cbbbb";
  protected comments: Comment[] = [];
  constructor(private route: ActivatedRoute, private commentsService: CommentService) { }


  showComments() {

    const page = document.getElementById("book-page") as HTMLInputElement;
    page?.addEventListener('page', this.getValue);

    this.commentsService.getCommentsBefore(this.bookId, +page.value)
      .subscribe(comments => {
        this.comments = comments
      });

    this.updateComments();
  }

  updateComments() {
    const displayComments = document.getElementById('display-comments');

    this.comments.forEach(comment => {
      //creates html section elements with title and text
      const section = document.createElement('section');
      section.setAttribute('class', 'comment');

      const info = document.createElement('p');
      info.textContent = `${comment.username} on page ${comment.page}`;
      info.setAttribute('class', 'username-on-comment');
      section.appendChild(info);

      const p = document.createElement('p');
      p.textContent = comment.text;
      section.appendChild(p);
      displayComments?.appendChild(section);
    })
  };


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

    const comment: Comment = { id: this.generateId(), username: username!.value, text: commentText!.value, page: +page!.value, bookId: this.bookId };

    this.comments.push(comment);
    this.commentsService.addComment(comment);
    console.log("here");
    this.updateComments();


  }
}
