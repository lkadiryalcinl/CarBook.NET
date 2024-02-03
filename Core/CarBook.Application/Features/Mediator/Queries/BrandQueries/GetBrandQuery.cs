using CarBook.Application.Features.Mediator.Results.BrandResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BrandQueries
{
    public class GetBrandQuery : IRequest<List<GetBrandQueryResult>>
    {
    }
}
