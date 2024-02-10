using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetLast3BlogsWithAuthorQuery : IRequest<List<GetLast3BlogsWithAuthorQueryResult>>
    {

    }
}
