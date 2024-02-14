using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentQuery : IRequest<List<GetCommentQueryResult>>
    {
    }
}
