using CarBook.Application.Features.Mediator.Commands.ContactCommand;
using CarBook.Application.Features.Mediator.Queries.ContactQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _mediator.Send(new GetContactQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _mediator.Send(new GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand request)
        {
            await _mediator.Send(request);
            return Ok("İletişim bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _mediator.Send(new RemoveContactCommand(id));
            return Ok("İletişim bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand request)
        {
            await _mediator.Send(request);
            return Ok("İletişim bilgisi güncellendi.");
        }
    }
}
