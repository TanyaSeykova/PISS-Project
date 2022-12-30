using RWM.Data.Models;
using RWM.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWM.Services.Extensions
{
    public static class BookMapper
    {
        public static CommentlessBook ToBookWithoutComments(this Book book)
        {
            var newCometlessBook = new CommentlessBook()
            {
                Author = book.Author,
                Series = book.Series,
                Description = book.Description,
                Pages = book.Pages,
                CoverImgUrl = book.CoverImgUrl,
                Id = book.Id,
                Title = book.Title
            };

            return newCometlessBook;
        }
    }
}
