using CarBook.Application.Features.Mediator.Commands.CommentCommand;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _mediator.Send(new GetCommentQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(value);
        }
        
        [HttpGet("GetCommentListByBlogId/{id}")]
        public async Task<IActionResult> GetCommentListByBlogId(int id)
        {
            var value = await _mediator.Send(new GetCommentsByBlogIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand request)
        {
            await _mediator.Send(request);
            return Ok("Kategori bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Kategori bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand request)
        {
            await _mediator.Send(request);
            return Ok("Kategori bilgisi güncellendi.");
        }
    }
}
