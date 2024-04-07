using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentByIdQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetCommentByIdQueryResult
            {
                Name = value.Name,
                BlogID = value.BlogID,
                Content = value.Content,
                CreatedDate = value.CreatedDate,
                ImageUrl = value.imageUrl,
                Mail = value.Mail
            };
        }
    }
}
