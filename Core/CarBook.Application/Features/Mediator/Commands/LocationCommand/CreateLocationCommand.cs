using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommand
{
    public class CreateLocationCommand : IRequest
    {
        public string Name { get; set; }
    }
}
