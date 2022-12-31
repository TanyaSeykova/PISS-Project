using Microsoft.EntityFrameworkCore;
using RWM.Data.Data;
using RWM.Data.Models;
using RWM.Services.Classes;
using RWM.Services.Contracts;
using RWM.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWM.Services
{
    public class BookService : IBookService
    {
        private RWMDbContext _context;

        public BookService(RWMDbContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBook(Guid id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(x => x.Id == id);

            if(book == null)
            {
                throw new ArgumentNullException($"Book with id: {id} does not exist");
            }
            return book;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public void AddBooks(List<Book> books)
        {
            var booksCount = _context.Books.ToList().Count;
            if(booksCount > 0)
            {
                return;
            }
            foreach (var book in books)
            {
                _context.Add(book);
            }
            _context.SaveChanges();

        }


    }
}
