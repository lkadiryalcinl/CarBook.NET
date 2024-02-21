using CarBook.Application.Features.Mediator.Commands.PricingCommand;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand request)
        {
            await _mediator.Send(request);
            return Ok("Fiyat bilgisi eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Fiyat bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand request)
        {
            await _mediator.Send(request);
            return Ok("Fiyat bilgisi güncellendi.");
        }
    }
}
