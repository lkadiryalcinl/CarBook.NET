using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BannerCommand
{
    public class UpdateBannerCommand : IRequest
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
