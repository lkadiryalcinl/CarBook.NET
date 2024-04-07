using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces.CommentInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentsCountByBlogIdQueryHandler : IRequestHandler<GetCommentsCountByBlogIdQuery, GetCommentsCountByBlogIdQueryResult>
    {
        private readonly ICommentRepository _repository;

        public GetCommentsCountByBlogIdQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentsCountByBlogIdQueryResult> Handle(GetCommentsCountByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCommentsCountByBlogId(request.Id);
            return new GetCommentsCountByBlogIdQueryResult
            {
                CommentCount = value
            };
        }
    }
}
