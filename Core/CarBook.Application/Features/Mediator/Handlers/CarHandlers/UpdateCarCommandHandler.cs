using CarBook.Application.Features.Mediator.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);
            value.Transmission = request.Transmission;
            value.BigImageUrl = request.BigImageUrl;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Fuel = request.Fuel;
            value.Seat = request.Seat;
            value.Kilometer = request.Kilometer;
            value.Model = request.Model;
            value.Luggage = request.Luggage;
            value.BrandID = request.BrandID;
            await _repository.UpdateAsync(value);
        }
    }
}
