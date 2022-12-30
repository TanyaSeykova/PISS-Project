using Newtonsoft.Json;
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
    public class BookJsonReader : IBookJsonReader
    {
        private readonly RWMDbContext _context;
        private readonly IBookService _bookService;

        public BookJsonReader(RWMDbContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }

        public void ReadJsonFile()
        {
            var booksCount = _context.Books.ToList().Count;

            if(booksCount == 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "converted-dataset.json");
                Console.WriteLine(path);
                using (var reader = new StreamReader(path))
                {
                    var booksJson = reader.ReadToEnd();
                    var booksJsonItems = JsonConvert.DeserializeObject<List<BookJsonModel>>(booksJson);
                    var books = new List<Book>();
                    foreach(var book in booksJsonItems)
                    {
                        books.Add(book.ToBook());
                    }
                    _bookService.AddBooks(books);
                }
            }
        }
    }
}
