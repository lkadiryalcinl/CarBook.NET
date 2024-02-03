using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CategoryCommand
{
    public class RemoveCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
