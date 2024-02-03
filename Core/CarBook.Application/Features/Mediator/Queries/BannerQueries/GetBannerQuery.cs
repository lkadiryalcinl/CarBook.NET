using CarBook.Application.Features.Mediator.Results.BannerResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BannerQueries
{
    public class GetBannerQuery : IRequest<List<GetBannerQueryResult>>
    {
    }
}
