using CarBook.Application.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarQueries
{
    public class GetCarByIdQuery : IRequest<GetCarByIdQueryResult>
    {
        public GetCarByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
