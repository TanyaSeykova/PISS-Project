using Microsoft.AspNetCore.Mvc;
using RWM.Data.Models;
using RWM.Services.Classes;
using RWM.Services.Contracts;

namespace RWM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            try
            {
                return Ok(await _bookService.GetBook(id));
            }
            catch(ArgumentException ae)
            {
                return NotFound(ae.Message);
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CommentlessBook>>> GetBooks()
        {
            return Ok(await _bookService.GetBooks());
        }
    }
}
