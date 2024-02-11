using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    internal class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, GetBlogByAuthorIdQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByAuthorIdQueryResult> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogByAuthorId(request.Id);
            return new GetBlogByAuthorIdQueryResult
            {
                AuthorDescription = values.Author.Description,
                AuthorName = values.Author.Name,
                AuthorImageUrl = values.Author.ImageUrl,
            };
        }
    }
}
