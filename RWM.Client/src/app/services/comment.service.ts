import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Comment } from '../models/comment.model';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  public getCommentsBefore(bookId: string, page: number) {
    return this.http.get<Comment[]>(`http://localhost:7256/Comment/for-book/${bookId}/before-page/${page}`);

  }

  public addComment(newComm: Comment) {
    return this.http.post<Comment>("http://localhost:7256/Comment", newComm ).subscribe();
  }

}
