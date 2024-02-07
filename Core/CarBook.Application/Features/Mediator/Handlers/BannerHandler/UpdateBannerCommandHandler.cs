using CarBook.Application.Features.Mediator.Commands.BannerCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);
            value.VideoDescription = request.VideoDescription;
            value.Description = request.Description;
            value.VideoUrl = request.VideoUrl;
            value.Title = request.Title;

            await _repository.UpdateAsync(value);
        }
    }
}
