using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommand
{
    public class UpdateServiceCommand : IRequest
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
