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
    }
}
