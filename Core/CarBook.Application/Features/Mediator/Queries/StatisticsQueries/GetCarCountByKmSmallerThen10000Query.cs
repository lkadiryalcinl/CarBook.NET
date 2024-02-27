using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarCountByKmSmallerThen10000Query:IRequest<GetCarCountByKmSmallerThen10000QueryResult>
    {
    }
}
