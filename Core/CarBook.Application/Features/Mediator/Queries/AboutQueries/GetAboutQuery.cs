using CarBook.Application.Features.Mediator.Results.AboutResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetAboutQuery : IRequest<List<GetAboutQueryResult>>
    {
    }
}
