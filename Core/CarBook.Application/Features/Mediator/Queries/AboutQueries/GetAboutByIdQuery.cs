using CarBook.Application.Features.Mediator.Results.AboutResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetAboutByIdQuery : IRequest<GetAboutByIdQueryResult>
    {
        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
