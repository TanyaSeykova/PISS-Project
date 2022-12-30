using RWM.Data.Models;
using RWM.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWM.Services.Extensions
{
    public static class BookJsonMapper
    {
        public static Book ToBook(this BookJsonModel book)
        {
            var newBook = new Book()
            {
                Author = book.Author,
                Description = book.Description,
                Pages = uint.Parse(book.Pages),
                Series = book.Series,
                Title = book.Title,
                CoverImgUrl = book.CoverImg
            };

            return newBook;
        }
    }
}
