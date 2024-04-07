using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentsCountByBlogIdQuery: IRequest<GetCommentsCountByBlogIdQueryResult>
    {
        public int Id { get; set; }

        public GetCommentsCountByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
