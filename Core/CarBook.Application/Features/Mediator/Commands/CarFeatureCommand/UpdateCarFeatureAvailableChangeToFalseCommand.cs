using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommand
{
    public class UpdateCarFeatureAvailableChangeToFalseCommand : IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvailableChangeToFalseCommand(int id)
        {
            Id = id;
        }
    }
}
