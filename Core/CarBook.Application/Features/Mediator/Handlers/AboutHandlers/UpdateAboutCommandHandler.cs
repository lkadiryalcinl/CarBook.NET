using CarBook.Application.Features.Mediator.Commands.AboutCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);
            value.Title = request.Title;
            value.Description = request.Description;
            value.ImageUrl = request.ImageUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
