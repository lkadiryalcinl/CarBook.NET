using CarBook.Application.Features.Mediator.Results.ContactResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ContactQueries
{
    public class GetContactByIdQuery : IRequest<GetContactByIdQueryResult>
    {
        public int Id { get; set; }

        public GetContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
