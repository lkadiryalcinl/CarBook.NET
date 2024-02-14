using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentByIdQuery : IRequest<GetCommentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
