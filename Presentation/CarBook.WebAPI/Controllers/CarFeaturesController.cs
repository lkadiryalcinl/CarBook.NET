using CarBook.Application.Features.Mediator.Commands.CarFeatureCommand;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpGet("CarFeatureChangeAvailableToFalse/{id}")]
        public IActionResult CarFeatureChangeAvailableToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok();
        }

        [HttpGet("CarFeatureChangeAvailableToTrue/{id}")]
        public IActionResult CarFeatureChangeAvailableToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCarFeatureByCarID(CreateCarFeatureByCarCommand createCarFeatureByCarCommand)
        {
            _mediator.Send(createCarFeatureByCarCommand);
            return Ok("Ekleme yapıldı.");
        }
    }
}
