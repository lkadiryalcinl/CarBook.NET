using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommand
{
    public class CreatePricingCommand : IRequest
    {
        public string Name { get; set; }
    }
}
