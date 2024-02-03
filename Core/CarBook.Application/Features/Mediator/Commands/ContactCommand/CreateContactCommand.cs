using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ContactCommand
{
    public class CreateContactCommand : IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
