using CarBook.Application.Features.Mediator.Commands.CommentCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public UpdateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);
            value.Name = request.Name;
            value.CreatedDate = request.CreatedDate;
            value.Content = request.Content;
            value.imageUrl = request.ImageUrl;
            value.BlogID = request.BlogID;
            value.Mail = request.Mail;
            await _repository.UpdateAsync(value);
        }
    }
}
