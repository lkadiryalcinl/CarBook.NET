using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BrandCommand
{
    public class UpdateBrandCommand : IRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
