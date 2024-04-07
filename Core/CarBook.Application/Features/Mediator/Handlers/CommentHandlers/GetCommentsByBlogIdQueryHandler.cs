using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces.CommentInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentsByBlogIdQueryHandler : IRequestHandler<GetCommentsByBlogIdQuery, List<GetCommentsByBlogIdQueryResult>>
    {
        private readonly ICommentRepository _repository;

        public GetCommentsByBlogIdQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentsByBlogIdQueryResult>> Handle(GetCommentsByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCommentsByBlogId(request.Id);
            return values.Select(x => new GetCommentsByBlogIdQueryResult
            {
                ID = x.ID,
                Name = x.Name,
                Content = x.Content,
                imageUrl = x.imageUrl,
                CreatedDate = x.CreatedDate,
                BlogID = x.BlogID,
                Mail = x.Mail,
            }).ToList();
        }
    }
}
