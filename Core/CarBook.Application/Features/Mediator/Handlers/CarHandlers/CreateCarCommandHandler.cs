using CarBook.Application.Features.Mediator.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Car
            {
                BigImageUrl = request.BigImageUrl,
                Fuel = request.Fuel,
                CoverImageUrl = request.CoverImageUrl,
                Kilometer = request.Kilometer,
                Luggage = request.Luggage,
                Seat = request.Seat,
                Model = request.Model,
                Transmission = request.Transmission,
                BrandID = request.BrandID,
            });
        }
    }
}
