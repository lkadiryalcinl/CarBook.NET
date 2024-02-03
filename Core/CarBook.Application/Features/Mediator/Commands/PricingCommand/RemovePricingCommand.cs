using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommand
{
    public class RemovePricingCommand : IRequest
    {
        public int Id { get; set; }

        public RemovePricingCommand(int id)
        {
            Id = id;
        }
    }
}
