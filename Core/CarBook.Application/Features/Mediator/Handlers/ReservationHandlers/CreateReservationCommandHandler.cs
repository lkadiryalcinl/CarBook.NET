using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                CarID = request.CarID,
                DropOffLocationID = request.DropOffLocationID,
                PickUpLocationID = request.PickUpLocationID,
                Email = request.Email,
                DriverLicenseYear = request.DriverLicenseYear,
                Name = request.Name,
                Surname = request.Surname,
                Age = request.Age,
                Phone = request.Phone,
                Description = request.Description,
                Status = "Rezervasyon Alındı."
            });
        }
    }
}
