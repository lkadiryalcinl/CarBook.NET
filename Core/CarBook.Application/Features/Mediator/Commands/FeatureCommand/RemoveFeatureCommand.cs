using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommand
{
    public class RemoveFeatureCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveFeatureCommand(int id)
        {
            Id = id;
        }
    }
}
