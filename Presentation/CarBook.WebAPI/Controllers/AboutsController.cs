using CarBook.Application.Features.Mediator.Commands.AboutCommand;
using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _mediator.Send(new GetAboutQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _mediator.Send(new GetAboutByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand request)
        {
            await _mediator.Send(request);
            return Ok("Hakkında bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return Ok("Hakkında bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand request)
        {
            await _mediator.Send(request);
            return Ok("Hakkında bilgisi güncellendi.");
        }
    }
}
