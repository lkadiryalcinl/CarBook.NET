using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ContactCommand
{
    public class RemoveContactCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveContactCommand(int id)
        {
            Id = id;
        }
    }
}
