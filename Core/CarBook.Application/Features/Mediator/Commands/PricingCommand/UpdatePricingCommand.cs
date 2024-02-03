using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommand
{
    public class UpdatePricingCommand : IRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
