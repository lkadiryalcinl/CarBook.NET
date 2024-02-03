using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommand
{
    public class UpdateLocationCommand : IRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
