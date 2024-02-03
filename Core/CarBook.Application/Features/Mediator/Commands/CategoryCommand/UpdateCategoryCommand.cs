using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CategoryCommand
{
    public class UpdateCategoryCommand : IRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
