using CarBook.Application.Features.Mediator.Commands.ServiceCommand;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand request)
        {
            await _mediator.Send(request);
            return Ok("Hizmet bilgisi eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return Ok("Hizmet bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand request)
        {
            await _mediator.Send(request);
            return Ok("Hizmet bilgisi güncellendi.");
        }
    }
}
