using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommand
{
    public class CreateCommentCommand : IRequest
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int BlogID { get; set; }
    }
}
