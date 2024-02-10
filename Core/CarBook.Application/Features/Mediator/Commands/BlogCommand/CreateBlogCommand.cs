using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommand
{
    public class CreateBlogCommand : IRequest
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
