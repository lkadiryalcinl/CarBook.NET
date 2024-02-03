using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommand
{
    public class CreateFeatureCommand : IRequest
    {
        public string Name { get; set; }
    }
}
