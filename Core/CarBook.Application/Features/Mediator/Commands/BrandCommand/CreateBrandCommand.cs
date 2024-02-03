using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BrandCommand
{
    public class CreateBrandCommand : IRequest
    {
        public string Name { get; set; }
    }
}
