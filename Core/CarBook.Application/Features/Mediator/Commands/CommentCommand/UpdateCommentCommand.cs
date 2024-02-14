using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommand
{
    public class UpdateCommentCommand : IRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int BlogID { get; set; }
    }
}
