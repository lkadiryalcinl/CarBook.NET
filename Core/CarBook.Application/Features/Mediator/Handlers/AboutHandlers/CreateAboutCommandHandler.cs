using CarBook.Application.Features.Mediator.Commands.AboutCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new About
            {
                Title = request.Title,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
            });
        }
    }
}
