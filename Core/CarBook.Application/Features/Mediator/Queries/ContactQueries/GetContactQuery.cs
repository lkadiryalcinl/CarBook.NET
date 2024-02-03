using CarBook.Application.Features.Mediator.Results.ContactResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ContactQueries
{
    public class GetContactQuery : IRequest<List<GetContactQueryResult>>
    {
    }
}
