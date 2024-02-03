using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BannerCommand
{
    public class RemoveBannerCommand : IRequest
    {
        public RemoveBannerCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
