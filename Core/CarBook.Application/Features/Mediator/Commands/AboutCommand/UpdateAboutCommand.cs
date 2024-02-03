using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AboutCommand
{
    public class UpdateAboutCommand : IRequest
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
