using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommand
{
    public class UpdateSocialMediaCommand : IRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
