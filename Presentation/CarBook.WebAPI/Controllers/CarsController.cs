using CarBook.Application.Features.Mediator.Commands.CarCommand;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _mediator.Send(new GetCarQuery());
            return Ok(values);
        }
        
        [HttpGet("GetCarsListWithBrand")]
        public async Task<IActionResult> GetCarsListWithBrand()
        {
            var values = await _mediator.Send(new GetCarWithBrandQuery());
            return Ok(values);
        }
        
        [HttpGet("GetLast5CarsWithBrand")]
        public async Task<IActionResult> GetLast5CarsWithBrand()
        {
            var values = await _mediator.Send(new GetLast5CarsWithBrandQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _mediator.Send(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand request)
        {
            await _mediator.Send(request);
            return Ok("Araba bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _mediator.Send(new RemoveCarCommand(id));
            return Ok("Araba bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand request)
        {
            await _mediator.Send(request);
            return Ok("Araba bilgisi güncellendi.");
        }
    }
}
