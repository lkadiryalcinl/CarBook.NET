using CarBook.Application.Features.Mediator.Results.BrandResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BrandQueries
{
    public class GetBrandByIdQuery : IRequest<GetBrandByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }
    }
}
