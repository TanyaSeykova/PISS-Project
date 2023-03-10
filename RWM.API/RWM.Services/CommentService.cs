using Microsoft.EntityFrameworkCore;
using RWM.Data.Data;
using RWM.Data.Models;
using RWM.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWM.Services
{
    public class CommentService : ICommentService
    {
        private RWMDbContext _context;

        public CommentService(RWMDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> GetComment(Guid id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null)
            {
                throw new ArgumentException($"Comment with id: {id} was not found");
            }
            return comment;
        }
        public async Task<Comment> AddComment(Comment comment)
        {
            var book = _context.Books.FirstOrDefault(c => c.Id == comment.BookId);
            if (book == null)
            {
                throw new ArgumentException($"Book with id: {comment.BookId} for comment with id: {comment.Id} was not found");
            }
            if (comment.Page < 1 || comment.Page > book.Pages)
            {
                throw new ArgumentException($"Cannot put comment on page: {comment.Page}, Book has {book.Pages} pages");
            }
            comment.Id = new Guid();
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<List<Comment>> GetCommentsForBook(Guid bookId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null)
            {
                throw new ArgumentException($"Book with id: {bookId} was not found");
            }
            var comments = await _context.Comments.Where(c => c.BookId == bookId).ToListAsync();
            return comments;

        }

        public async Task<List<Comment>> GetCommentsForBookBeforePage(Guid bookId, int page)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null)
            {
                throw new ArgumentException($"Book with id: {bookId} was not found");
            }
            if (page < 1 || page > book.Pages)
            {
                throw new ArgumentException($"Page is either more than the book's pages '{book.Pages}' or is less than 1. Page: {page}");
            }
            var comments = await _context.Comments.Where(c => c.BookId == bookId && c.Page <= page).ToListAsync();
            return comments;
        }
    }
}
