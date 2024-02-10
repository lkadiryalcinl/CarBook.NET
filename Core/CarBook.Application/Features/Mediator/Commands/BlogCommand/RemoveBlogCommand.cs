using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommand
{
    public class RemoveBlogCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveBlogCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
