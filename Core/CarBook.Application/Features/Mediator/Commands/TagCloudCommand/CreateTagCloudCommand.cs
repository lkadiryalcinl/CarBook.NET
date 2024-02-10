using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommand
{
    public class CreateTagCloudCommand : IRequest
    {
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
