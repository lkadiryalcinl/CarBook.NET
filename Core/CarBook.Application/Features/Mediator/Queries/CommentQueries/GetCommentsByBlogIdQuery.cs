using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentsByBlogIdQuery : IRequest<List<GetCommentsByBlogIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCommentsByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
