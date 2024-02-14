using CarBook.Application.Features.Mediator.Commands.CommentCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public RemoveCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
