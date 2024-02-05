using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddressCommand
{
    public class RemoveFooterAddressCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveFooterAddressCommand(int id)
        {
            Id = id;
        }
    }
}
