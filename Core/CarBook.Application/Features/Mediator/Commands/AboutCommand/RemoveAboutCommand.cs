using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AboutCommand
{
    public class RemoveAboutCommand : IRequest
    {
        public RemoveAboutCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
