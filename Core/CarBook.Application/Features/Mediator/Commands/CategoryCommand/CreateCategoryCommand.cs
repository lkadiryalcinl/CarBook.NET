using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CategoryCommand
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}
