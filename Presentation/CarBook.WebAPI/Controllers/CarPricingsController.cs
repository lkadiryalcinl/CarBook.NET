using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarPricingWithCar")]
        public async Task<IActionResult> GetCarPricingWithCar()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }
        
        [HttpGet("GetCarPricingWithCarDaily")]
        public async Task<IActionResult> GetCarPricingWithCarDaily()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarDailyQuery());
            return Ok(values);
        }
        
        [HttpGet("GetCarPricingWithTimePeriodList")]
        public async Task<IActionResult> GetCarPricingWithTimePeriodList()
        {
            var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
            return Ok(values);
        }
    }
}
