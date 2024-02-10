using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommand
{
    public class UpdateTagCloudCommand : IRequest
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
