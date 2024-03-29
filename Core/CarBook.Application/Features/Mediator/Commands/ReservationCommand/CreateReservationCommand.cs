using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ReservationCommand
{
    public class CreateReservationCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CarID { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
