using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommand
{
    public class UpdateFeatureCommand : IRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
