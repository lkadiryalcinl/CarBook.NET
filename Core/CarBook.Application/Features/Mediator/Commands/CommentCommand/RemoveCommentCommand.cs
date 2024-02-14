using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommand
{
    public class RemoveCommentCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCommentCommand(int id)
        {
            Id = id;
        }
    }
}
