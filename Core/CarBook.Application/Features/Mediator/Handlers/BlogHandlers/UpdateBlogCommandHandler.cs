using CarBook.Application.Features.Mediator.Commands.BlogCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);
            value.AuthorId = request.AuthorId;
            value.Title = request.Title;
            value.CreatedDate = request.CreatedDate;
            value.CategoryId = request.CategoryId;
            value.CoverImageUrl = request.CoverImageUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
