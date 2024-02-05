using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddressCommand
{
    public class UpdateFooterAddressCommand : IRequest
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
