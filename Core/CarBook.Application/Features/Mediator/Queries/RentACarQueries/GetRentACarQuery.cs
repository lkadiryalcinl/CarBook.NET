using CarBook.Application.Features.Mediator.Results.RentACarResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarQuery : IRequest<List<GetRentACarQueryResult>>
    {
        public int LocationID { get; set; }
        public bool Available { get; set; }
    }
}
