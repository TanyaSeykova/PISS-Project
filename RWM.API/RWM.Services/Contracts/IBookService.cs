using RWM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWM.Services.Contracts
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetBook(Guid id);
    }
}
