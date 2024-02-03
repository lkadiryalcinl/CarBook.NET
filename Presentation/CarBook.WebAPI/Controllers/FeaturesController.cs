using CarBook.Application.Features.Mediator.Commands.FeatureCommand;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var value = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand request)
        {
            await _mediator.Send(request);
            return Ok("Özellik bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Özellik bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand request)
        {
            await _mediator.Send(request);
            return Ok("Özellik bilgisi güncellendi.");
        }
    }
}
