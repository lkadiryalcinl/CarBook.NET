using CarBook.Application.Features.Mediator.Commands.BannerCommand;
using CarBook.Application.Features.Mediator.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _mediator.Send(new GetBannerQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _mediator.Send(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand request)
        {
            await _mediator.Send(request);
            return Ok("Banner bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _mediator.Send(new RemoveBannerCommand(id));
            return Ok("Banner bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand request)
        {
            await _mediator.Send(request);
            return Ok("Banner bilgisi güncellendi.");
        }
    }
}
