using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionsController : ControllerBase
	{
		private readonly IMediator _mediator;
		public CarDescriptionsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> CarDescriptionByCarId(int id)
		{
			var values = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
			return Ok(values);
		}
	}
}
