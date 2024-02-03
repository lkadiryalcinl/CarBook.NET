using CarBook.Application.Features.Mediator.Commands.BrandCommand;
using CarBook.Application.Features.Mediator.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _mediator.Send(new GetBrandQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _mediator.Send(new GetBrandByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand request)
        {
            await _mediator.Send(request);
            return Ok("Marka bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _mediator.Send(new RemoveBrandCommand(id));
            return Ok("Marka bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand request)
        {
            await _mediator.Send(request);
            return Ok("Marka bilgisi güncellendi.");
        }
    }
}
