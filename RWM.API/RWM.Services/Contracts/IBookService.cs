using RWM.Data.Models;
using RWM.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWM.Services.Contracts
{
    public interface IBookService
    {
        Task<List<CommentlessBook>> GetBooks();
        Task<Book> GetBook(Guid id);
        void AddBooks(List<Book> books);
    }
}
