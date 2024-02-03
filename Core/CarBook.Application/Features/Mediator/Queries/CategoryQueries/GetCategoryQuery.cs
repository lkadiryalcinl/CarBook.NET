using CarBook.Application.Features.Mediator.Results.CategoryResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CategoryQueries
{
    public class GetCategoryQuery : IRequest<List<GetCategoryQueryResult>>
    {
    }
}
