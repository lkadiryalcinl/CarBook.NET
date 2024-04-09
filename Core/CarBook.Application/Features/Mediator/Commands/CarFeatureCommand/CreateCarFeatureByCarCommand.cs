using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommand
{
    public class CreateCarFeatureByCarCommand : IRequest
    {
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }
}
