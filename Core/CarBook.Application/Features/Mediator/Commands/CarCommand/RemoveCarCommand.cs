using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarCommand
{

    public class RemoveCarCommand : IRequest
    {
        public RemoveCarCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
