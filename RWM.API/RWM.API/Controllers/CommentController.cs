using Microsoft.AspNetCore.Mvc;
using RWM.Data.Models;
using RWM.Services.Contracts;

namespace RWM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private ICommentService _commentService;

        public CommentController(ICommentService bookService)
        {
            _commentService = bookService;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Comment>> GetComment(Guid id)
        {
            try
            {
                return Ok(await _commentService.GetComment(id));
            }
            catch (ArgumentException ae)
            {
                return NotFound(ae.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> AddComment([FromBody] Comment comment)
        {
            try
            {
                return Ok(await _commentService.AddComment(comment));
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        [HttpGet("for-book/{bookId:Guid}")]
        public async Task<ActionResult<List<Comment>>> GetCommentsForBook(Guid bookId)
        {
            try
            {
                return Ok(await _commentService.GetCommentsForBook(bookId));
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        [HttpGet("for-book/{bookId:Guid}/before-page/{page:int}")]
        public async Task<ActionResult<List<Comment>>> GetCommentsBeforePage(Guid bookId, int page)
        {
            try
            {
                return Ok(await _commentService.GetCommentsForBookBeforePage(bookId, page));
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }
        
    }
}
